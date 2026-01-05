# .NET 8 Minimal API on Cloudflare Containers

[![Build and Push](https://github.com/kourain/minimalapi-cloudflare/actions/workflows/cloudflare-deploy.yml/badge.svg)](https://github.com/kourain/minimalapi-cloudflare/actions/workflows/cloudflare-deploy.yml)

Mẫu template hoàn chỉnh để triển khai .NET 8 Minimal API lên **Cloudflare Containers** với CI/CD tự động.

## 🚀 Features

- ✅ .NET 8 Minimal API
- 🐳 Docker multi-stage build (tối ưu image size)
- ☁️ Cloudflare Containers ready
- 🔄 GitHub Actions CI/CD automation
- 📊 Health check endpoints
- 🎯 Production-ready configuration
- 📝 Comprehensive documentation
- 🛠️ Make commands để dễ dàng quản lý

## 📋 Yêu cầu

- **Tài khoản Cloudflare** (với Containers enabled)
- **Docker** 20.10+
- **.NET 8 SDK** (tùy chọn, nếu build locally)
- **Git** & **GitHub Account**
- **curl** hoặc **Postman** (để test API)

## ⚡ Quick Start

### 1. Clone & Setup
```bash
git clone https://github.com/kourain/minimalapi-cloudflare.git
cd minimalapi-cloudflare
cp .env.example .env
```

### 2. Build & Run Local
```bash
# Sử dụng Make
make build
make run

# Hoặc Docker Compose
docker-compose up -d
```

### 3. Test API
```bash
# Test main endpoint
curl http://localhost:8080/

# Test health check
curl http://localhost:8080/healthz

# Sử dụng Make
make test
```

## 📦 Project Structure

```
.
├── src/
│   └── MinimalApiSample/
│       ├── Program.cs              # API logic
│       └── MinimalApiSample.csproj  # Dependencies
├── .github/
│   └── workflows/
│       └── cloudflare-deploy.yml    # GitHub Actions CI/CD
├── Dockerfile                       # Multi-stage build
├── docker-compose.yml              # Development environment
├── docker-compose.prod.yml         # Production environment
├── wrangler.toml                   # Cloudflare Workers config
├── .env.example                    # Environment template
├── DEPLOYMENT.md                   # Detailed deployment guide
├── CONTRIBUTING.md                 # Contribution guidelines
└── Makefile                        # Useful commands
```

## 🐳 Docker Commands

### Build
```bash
docker build -t minimalapi:local .
```

### Run
```bash
docker run -p 8080:8080 \
  -e ASPNETCORE_ENVIRONMENT=Development \
  minimalapi:local
```

### Docker Compose
```bash
# Start
docker-compose up -d

# View logs
docker-compose logs -f api

# Stop
docker-compose down
```

## ☁️ Cloudflare Deployment

### GitHub Actions (Automatic)

1. **Configure Secrets**
   - Settings → Secrets and variables → Actions
   - Add: `CLOUDFLARE_API_TOKEN`, `CLOUDFLARE_ACCOUNT_ID`

2. **Push to main**
   ```bash
   git push origin main
   ```

3. **Monitor** in Actions tab

### Manual Deployment

```bash
# Login
wrangler login

# Deploy
wrangler deploy
```

📖 Xem [DEPLOYMENT.md](DEPLOYMENT.md) cho hướng dẫn chi tiết.

## 🛠️ Make Commands

```bash
make help           # Xem tất cả commands
make build          # Build Docker image
make run            # Run container
make test           # Test API endpoints
make clean          # Cleanup
make compose-up     # Start docker-compose
make compose-down   # Stop docker-compose
make logs           # View logs
make deploy         # Deploy to Cloudflare
```

## 📊 API Endpoints

| Endpoint | Method | Description |
|----------|--------|-------------|
| `/` | GET | Main endpoint - returns greeting message |
| `/healthz` | GET | Health check endpoint |

### Example Responses

```bash
# GET /
{
  "message": "Hello from .NET 8 Minimal API on Cloudflare Containers"
}

# GET /healthz
OK
```

## 🔐 Security

- ✅ Environment variables trong `.env` (không commit)
- ✅ GitHub Secrets cho sensitive data
- ✅ Health checks configured
- ✅ Resource limits configured
- ✅ Proper logging

## 📈 Monitoring

### Cloudflare Dashboard
- Workers Tail: `wrangler tail`
- Logs: Cloudflare Analytics

### Local
- Docker logs: `docker-compose logs -f api`
- Health check: `curl http://localhost:8080/healthz`

## 🚀 Performance Tips

1. **Image size**: ~110MB (ASP.NET runtime)
2. **Startup time**: ~2-3 seconds
3. **Memory**: ~128MB baseline
4. **CPU**: Cloudflare auto-scaling

## 📚 Documentation

- [DEPLOYMENT.md](DEPLOYMENT.md) - Chi tiết triển khai
- [CONTRIBUTING.md](CONTRIBUTING.md) - Quy tắc đóng góp
- [Cloudflare Docs](https://developers.cloudflare.com/containers)
- [.NET 8 Docs](https://learn.microsoft.com/dotnet)

## 🤝 Contributing

Hãy tạo issue hoặc PR! Xem [CONTRIBUTING.md](CONTRIBUTING.md).

## 📄 License

MIT License - xem [LICENSE](LICENSE)

## 💬 Support

- GitHub Issues: Báo bug hoặc request features
- Discussions: Hỏi đáp kỹ thuật

---

**Made with ❤️ for Cloud-native .NET developers**
