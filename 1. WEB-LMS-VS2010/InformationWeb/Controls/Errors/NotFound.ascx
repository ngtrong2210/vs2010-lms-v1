<%@ Control Language="C#" %>
<!DOCTYPE html>
<html lang="vi">
    <head>
        <meta charset="utf-8" />
        <title>Không tìm thấy</title>
        <link rel="stylesheet" href="<%= ResolveUrl("~/assets/lms/vendor/bootstrap.min.css") %>" />
    </head>
    <body class="bg-light">
        <main class="container py-5 text-center">
            <h1 class="display-1 fw-bold text-primary">404</h1>
            <h2>Không tìm thấy nội dung</h2>
            <p class="text-secondary">Đường dẫn hoặc dữ liệu bạn yêu cầu không tồn tại.</p>
            <a class="btn btn-primary" href="<%= ResolveUrl("~/") %>">Về trang chính</a>
        </main>
    </body>
</html>
