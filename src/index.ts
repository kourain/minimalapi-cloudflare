import { Container, getRandom, getContainer } from '@cloudflare/containers'; // in a real Worker

export class MyContainer extends Container {
    defaultPort = 8080; // The default port for the container to listen on
    sleepAfter = '1m'; // Sleep the container if no requests are made in this timeframe

    // default env vars to set in the container when starting
    envVars = {
        MESSAGE: 'I was passed in via the container class!',
    };

    // these lifecycle hooks are called whenever the container starts, stops, or errors
    override onStart() {
        console.log('Container successfully started');
    }

    override onStop() {
        console.log('Container successfully shut down');
    }

    override onError(error: unknown) {
        console.log('Container error:', error);
    }
}

export default {
    async fetch(
        request: Request,
        env: { MY_CONTAINER: DurableObjectNamespace<MyContainer> }
    ): Promise<Response> {
        const pathname = new URL(request.url).pathname;
        // If you want to route requests to a specific container,
        // pass a unique container identifier to .get()

        // Cách 3: Sử dụng AbortController để cancel request thực sự
        const TIMEOUT = 30;
        const controller = new AbortController();
        const timeoutId = setTimeout(() => controller.abort(), TIMEOUT * 1000);

        try {
            const containerInstance = getContainer(env.MY_CONTAINER, `${pathname}`);

            // Clone request và thêm signal
            const requestWithTimeout = new Request(request, {
                signal: controller.signal
            });

            const response = await containerInstance.fetch(requestWithTimeout);
            clearTimeout(timeoutId);
            return response;

        } catch (error: any) {
            clearTimeout(timeoutId);
            if (error.name === 'AbortError') {
                return new Response(`Request timeout after ${TIMEOUT} seconds`, {
                    status: 504,
                    statusText: 'Gateway Timeout',
                    headers: { 'Content-Type': 'text/plain' }
                });
            }
            return new Response(`Container request failed: ${error.message}`, {
                status: 500,
                statusText: 'Internal Server Error',
                headers: { 'Content-Type': 'text/plain' },
            });
        }
    },
};