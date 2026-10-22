---
name: no-blank-lines
description: >-
  Forbids inserted blank lines when writing or editing source. The next line
  sits directly under the previous line: no empty line between a parent tag
  and its child, between sibling tags, or inside a method, style rule, or SQL
  block. Indent exactly one level. Use whenever writing, editing, or formatting
  aspx, ascx, html, css, js, cs, sql, xml, or when the user mentions cách dòng,
  blank line, format code, không cách dòng.
---

# Không cách dòng

Áp dụng mọi lần viết hoặc sửa code, mọi project.

Dòng mới nằm ngay dưới dòng trước. Không chèn dòng trống giữa các dòng trong cùng một khối.

## Được phép

Một dòng trống chỉ khi tách method, class, hoặc `#region`.

## Cấm

- Dòng trống giữa thẻ mở và thẻ con.
- Dòng trống giữa các thẻ anh em.
- Dòng trống giữa các câu lệnh trong cùng method.
- Dòng trống trong một rule CSS, một khối SQL, một object literal.
- Thụt lề sâu hơn một cấp so với dòng cha.

## Markup

Sai:

```html
<div class="dorm-register-room-block">

                                            <div class="dorm-register-room-banner">
```

Đúng:

```html
<div class="dorm-register-room-block">
    <div class="dorm-register-room-banner">
        <span class="dorm-register-room-banner-lead">
            <span class="dorm-register-room-banner-title">Phòng</span>
        </span>
    </div>
</div>
```

## C#

Sai:

```csharp
private void BindRoom()
{

    if (roomId <= 0)
    {

        return;
    }

    LoadBeds(roomId);
}
```

Đúng:

```csharp
private void BindRoom()
{
    if (roomId <= 0)
    {
        return;
    }
    LoadBeds(roomId);
}
```

## Khi sửa file có sẵn

Đoạn vừa viết phải đặc như các dòng ngay trên và ngay dưới. Không format lại cả file để thêm khoảng cách.
