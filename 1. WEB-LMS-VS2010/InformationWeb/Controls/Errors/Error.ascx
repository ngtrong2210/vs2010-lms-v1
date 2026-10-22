<%@ Control Language="C#" %>
<!DOCTYPE html>
<html lang="vi">
    <head>
        <meta charset="utf-8" />
        <title>Lỗi hệ thống</title>
        <link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/vendor/bootstrap.min.css") %>" />
    </head>
    <body class="bg-light">
        <main class="container py-5 text-center">
            <h1 class="display-1 fw-bold text-danger">500</h1>
            <h2>Hệ thống đang gặp sự cố</h2>
            <p class="text-secondary">Lỗi đã được ghi nhận. Vui lòng thử lại sau.</p>
            <a class="btn btn-primary" href="<%= ResolveUrl("~/") %>">Về trang chính</a>
        </main>
    </body>
</html>
