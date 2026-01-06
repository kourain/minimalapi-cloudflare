# .NET C# Cloudflare Containers

[![Build and Push](https://github.com/kourain/minimalapi-cloudflare/actions/workflows/cloudflare-deploy.yml/badge.svg)](https://github.com/kourain/minimalapi-cloudflare/actions/workflows/cloudflare-deploy.yml)

Mẫu template hoàn chỉnh để triển khai .NET 9 Minimal API lên **Cloudflare Containers** với CI/CD tự động.

## 🚀 Features

- ✅ .NET 9 Minimal API
- 🐳 Docker multi-stage build (tối ưu image size)
- ☁️ Cloudflare Containers ready
- 📊 Health check endpoints
- 🎯 Production-ready configuration
- 📝 Comprehensive documentation
- 🛠️ Make commands để dễ dàng quản lý

## 📋 Yêu cầu

- **Tài khoản Cloudflare** (với Containers enabled: min 5 USD / Month)
- **.NET 9 SDK** (tùy chọn, cho quá trình phát triển)
- **Git** & **GitHub Account**

### Change Container Name

1. Open ``wrangler.jsonc``
2. Change ``containers.name``

### Instances Count ( Load Balancing )
  # BẠN BUỘC PHẢI ĐỂ SỐ LƯỢNG INSTANCE GIỐNG NHAU VÀ > 0 (Default: 1 ~ Load balancing OFF)
1. Open ``/src/index.ts``
  - Change ``MyContainer.InstanceCount``
2. Open ``wrangler.jsonc``
  - Change ``containers.max_instances``

## ☁️ Cloudflare Deployment

### Automatic Deployment

1. **Open Cloudflare Worker-Page Dashboard**
   - Create Application -> Link Github Repo
   - Branch: main

2. **Push to main**
   ```bash
   git push origin main
   ```

3. **Monitor** in Dashboard

### Manual Deployment

```bash
# Login
wrangler login

# Deploy
wrangler deploy
```

### Github CI/CD

1. Đổi tên ``.github/workflows/cloudflare-deploy.yml.txt`` -> ``.github/workflows/cloudflare-deploy.yml.txt``
2. Thêm Github Secret: ``CLOUDFLARE_API_TOKEN``
   Xem: https://developers.cloudflare.com/fundamentals/api/get-started/create-token

## 💬 Support

- GitHub Issues: Báo bug hoặc request features
- Discussions: Hỏi đáp kỹ thuật

---

**Made with ❤️ for Cloud-native .NET developers**
