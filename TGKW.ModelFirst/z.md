# model first 强烈推荐

## 安装 package
1.  Microsoft.EntityFrameworkCore.Design
2.  Pomelo.EntityFrameworkCore.MySql

## 在项目目录中执行
```
 dotnet tool install --global dotnet-ef #如果有就不用安装了
 dotnet ef migrations add InitialCreate
 dotnet ef database update
```


## 迁移
https://learn.microsoft.com/zh-cn/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
```
dotnet ef migrations add CreateSysUserCloumnUpdateTime
dotnet ef database update
```


## 其他
```
dotnet ef database update 0 # 回滚所有迁移

dotnet ef migrations remove # 删除最后一次迁移（重复执行可删除多个）
```