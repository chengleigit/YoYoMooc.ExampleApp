# 命令

------

### 一、dotnet



```bash
dotnet --version
dotnet restore 还原
dotnet run 运行

```

| 命令                       | 作用                   |
| -------------------------- | ---------------------- |
| docker image ls            | 查询所有的镜像         |
| docker pull                | 下载镜像               |
| docker rmi                 | 删除镜像               |
| docker build               | 创建一个自定义的镜像   |
| docker create              | 创建容器               |
| docker ps                  | 查询所有的容器         |
| docker start               | 启动容器               |
| docker stop                | 停止容器               |
| docker logs                | 查看容器的运行日志记录 |
| docker run                 | 创建并运行一个容器     |
| docker cp                  | 将文件复制到容器中     |
| docker diff                | 查看容器文件的变化     |
| docker exec                | 在容器中运行命令       |
| docker commit              | 将修改的容器创建为镜像 |
| docker tag                 | 为镜像分配一个标记     |
| docker login docker logout | 从镜像仓库中登录或注销 |
| docker push                | 将镜像发布到仓库中     |
| docker inspect             | 查看容器的详细配置     |

```
 docker rmi -f $(docker image ls -aq)  删除所有镜像

 docker rm $(docker ps -a -q) 删除所有容器
```

```bash
dotnet publish --framework netcoreapp3.1 --configuration Release --output dist 发布程序

创建一个自定义镜像
docker build . -t yoyomooc/exampleapp -f Dockerfile

创建容器
docker create -p 5000:80 --name exampleApp5000 yoyomooc/exampleapp

docker create -p 4000:80 --name exampleApp4000 yoyomooc/exampleapp

docker ps 查看运行容器
docker ps -a 查看所有容器

docker start exampleapp3000 启动容器
docker start $(docker ps -aq) 启动所有容器

docker stop exampleapp3000  停止指定容器
docker stop $(docker ps -q) 停止所有容器

docker logs exampleapp3000    查看容器日志
docker logs -f exampleapp3000 实时查看容器日志

docker run 等于 docker create+start 创建并运行容器

多用于测试，停止会自动删除
docker run -p 6500:80 --rm --name exampleApp6500 yoyomooc/exampleapp

进入容器内部
docker exec exampleApp4000 cat /app/wwwroot/css/site.css

apt-get update
apt-get install vim  安装vim工具

docker commit exampleApp4000 chneglei/exampleapp:changed 从容器中打包镜像

docker push chneglei/exampleapp:changed 将镜像推送到远程

```













## 拉取镜像

```bash
docker pull mcr.microsoft.com/dotnet/core/aspnet
```

Copy

拉取一个指定tag标签的镜像

```bash
docker pull mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
```



拉取该镜像下的所有Tag内容

```bash
docker pull --all-tags mcr.microsoft.com/dotnet/core/aspnet
```



## 镜像操作命令--基础部分

查看所有的镜像

```bash
docker image ls 

docker images 

docker image list
```

查看所有的镜像返回只返回镜像id

```bash
docker images -q
```



下面的命令会直接列出镜像结果，并且只包含镜像ID和仓库名：

```bash
docker	image	ls	--format	"{{.ID}}:	{{.Repository}}" 
docker	image	ls	--format	"table	{{.ID}}\t{{.Repository}}\t{{.Tag}}" 
```



删除镜像

```bash
docker image rm nginx
```



## 镜像操作命令==进阶篇

移除悬虚镜像

```bash
docker image prune
```



移除所有的悬虚镜像且包含未被任何容器使用的镜像

```bash
docker image prune -a
```



查看镜像所有细节命令

```bash
docker image inspect 镜像名称

docker image inspect nginx
```



删除所有的镜像

```bash
docker rmi $(docker images -q)
```



## 容器操作命令

查看所有容器

```bash
docker ps -a 
```



查看运行中的容器

```bash
docker ps  
```



运行一个新的容器

```bash
docker run mysql 
```



运行一个新容器 然后10秒后退出

```bash
docker run mysql sleep 10
```



运行一个容器，-d表示在后台运行，该命令将容器中的端口 80 映射到计算机上的端口 8080。

```bash
docker run -p 8080:80 -d mysql
```



进入某个容器环境

```bash
docker exec -it 容器名称ID bash
docker container exec -it 容器名称ID bash
```



启动指定容器

```bash
docker start 容器ID 
```



停止指定容器

```bash
docker stop 容器ID 
```



停止所有的容器

```bash
docker stop $(docker ps -a -q)
```



强制结束（杀进程）

```bash
docker kill $(docker ps -a -q)
```



删除所有的容器

```bash
docker rm $(docker ps -a -q)
```
