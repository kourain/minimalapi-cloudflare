# .NET C# Cloudflare Containers

[![Deploy to Cloudflare](https://deploy.workers.cloudflare.com/button)](https://deploy.workers.cloudflare.com/?url=https://github.com/kourain/.net-cloudflare-containers/tree/main)

Complete template for deploying .NET 9 Minimal API to **Cloudflare Containers** with CI/CD.

## 🚀 Features

- ✅ .NET 9 Minimal API
- 🐳 Docker multi-stage build (optimized image size)
- ☁️ Cloudflare Containers ready
- 📊 Health check endpoints
- 🎯 Production-ready configuration
- 📝 Comprehensive documentation

## 📋 Requirements

- **Cloudflare Account** (with Containers enabled: min 5 USD / Month)
- **.NET 9 SDK** (optional, for development)
- **Git** & **GitHub Account**

## Setup

### 1. Change Container Name

1. Open ``wrangler.jsonc``
2. Change ``containers.name``

### 2. Instances Count ( Load Balancing )

YOU MUST KEEP THE INSTANCE COUNT THE SAME AND > 0 (Default: 1 ~ Load balancing OFF)

1. Open ``/src/index.ts``
  - Change ``MyContainer.InstanceCount``
2. Open ``wrangler.jsonc``
  - Change ``containers.max_instances``

### 3. Performance

1. Open ``/src/index.ts``
2. vCPU ( 1 - 16 ):
  - Change ``containers.instance_type.vcpu``
3. Ram ( 256 - 12288 ~ 250MB - 12GB ):
  - Change ``containers.instance_type.memory_mib``
4. Disk ( max 20480 ~ 20GB )
  - Change ``containers.instance_type.disk_mb``

## ☁️ Cloudflare Deployment

### 1. Automatic Deployment

1. **Open Cloudflare Worker-Page Dashboard**
   - Create Application -> Link Github Repo
   - Branch: main

2. **Push to main**
   ```bash
   git push origin main
   ```

3. **Monitor** in Dashboard

### 2. Manual Deployment

```bash
# Login
wrangler login

# Deploy
wrangler deploy
```

### 3. Github CI/CD

1. Rename ``.github/workflows/cloudflare-deploy.yml.txt`` -> ``.github/workflows/cloudflare-deploy.yml``
2. Add Github Secret: ``CLOUDFLARE_API_TOKEN``
   See: https://developers.cloudflare.com/fundamentals/api/get-started/create-token

## 💬 Support

- GitHub Issues: Report bugs or request features
- Discussions: Technical Q&A

---

**Made with ❤️ for Cloud-native .NET developers**
