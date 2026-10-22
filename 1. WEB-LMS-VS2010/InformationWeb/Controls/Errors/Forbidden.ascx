<%@ Control Language="C#" %>
<!DOCTYPE html>
<html lang="vi">
    <head>
        <meta charset="utf-8" />
        <title>Không có quyền</title>
        <link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/vendor/bootstrap.min.css") %>" />
    </head>
    <body class="bg-light">
        <main class="container py-5 text-center">
            <h1 class="display-1 fw-bold text-warning">403</h1>
            <h2>Không có quyền truy cập</h2>
            <p class="text-secondary">Tài khoản hiện tại không được phép mở chức năng này.</p>
            <a class="btn btn-primary" href="<%= ResolveUrl("~/") %>">Về trang chính</a>
        </main>
    </body>
</html>
