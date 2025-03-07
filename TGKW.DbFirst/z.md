# db first

## 安装 package
1.  Microsoft.EntityFrameworkCore.Design
2.  Pomelo.EntityFrameworkCore.MySql

## 在项目目录中执行
```
dotnet ef dbcontext scaffold "server=localhost;port=3306;user=root;password=qQ123456!;database=tgkw_db" Pomelo.EntityFrameworkCore.MySql -o  jcjc_model -f

```
