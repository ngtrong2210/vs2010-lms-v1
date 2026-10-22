---
name: webforms-ui-only-sync
description: Modernize or synchronize the presentation of legacy ASP.NET Web Forms pages, master pages, and reusable ASCX controls from a visual reference while preserving all existing server-side behavior. Use for UI-only conversions where IDs, server-control types, postbacks, events, data binding, validation, and code-behind logic must remain unchanged, especially when shared controls require flexible col-auto layouts.
---

# Web Forms UI-Only Sync

Convert only the presentation layer. Treat the existing Web Forms behavior as an invariant, not as an opportunity to refactor.

## Non-negotiable boundary

- Do not change `.ascx.cs`, `.aspx.cs`, `.master.cs`, designer files, database calls, sessions, redirects, validation logic, or business logic unless the user separately authorizes logic changes.
- Preserve every server control's `ID`, control type, `runat`, `OnClick`, `OnSelectedIndexChanged`, `AutoPostBack`, `CausesValidation`, `ValidationGroup`, binding fields, visibility behavior, and UpdatePanel boundary.
- Do not replace an `asp:Button` with a `LinkButton`, add a new reset/search/view control, or wire a new event merely because it appears in the reference design.
- If the reference contains behavior that the current page does not have, omit that feature and report it as intentionally not implemented.
- UI-only edits may add or rearrange plain HTML wrappers, CSS classes, icons, labels, placeholders, page titles, breadcrumbs, and reusable CSS, provided they do not change postback or binding behavior.

## Layout rule for shared controls

Assume every reusable ASCX can be placed beside page-specific controls and may have an unknown intrinsic width.

- Wrap reusable controls with `col-auto` inside a wrapping row, for example `row g-3 align-items-end flex-wrap`.
- Do not assign fixed Bootstrap widths such as `col-2`, `col-4`, `col-md-3`, or `col-lg-6` to a shared control wrapper. These assumptions break when a page combines several controls.
- Use `col-auto` for action groups too. Use `col` or an explicit grow helper only for a page-owned field that is intentionally allowed to consume remaining space.
- Give flexible slots `min-width: 0` and `max-width: 100%`; let rows wrap and use `gap`/Bootstrap gutters instead of fixed margins.
- On small screens, allow control slots and actions to become full width through a shared responsive CSS rule. Do not encode page-specific widths into the shared ASCX.

Preferred shape:

```html
<div class="row g-3 align-items-end flex-wrap">
  <div class="col-auto cms-control-slot">
    <!-- existing shared ASCX; keep its server markup unchanged -->
  </div>
  <div class="col-auto cms-control-slot cms-control-slot-grow">
    <!-- page-owned field that may expand -->
  </div>
  <div class="col-auto cms-control-actions">
    <!-- existing server buttons only -->
  </div>
</div>
```

```css
.cms-control-slot {
  min-width: 0;
  max-width: 100%;
}

.cms-control-slot-grow {
  flex: 1 1 260px;
}

@media (max-width: 767.98px) {
  .cms-control-slot,
  .cms-control-actions {
    width: 100%;
  }
}
```

Adapt class names to the project's established naming system instead of duplicating equivalent helpers.

## Workflow

1. Inspect the master page, CSS load order, target markup, code-behind, and designer. Record the existing server-control IDs, types, events, validation, postback, binding, and UpdatePanel boundaries before editing.
2. Separate the reference's visual language from its extra functionality. Reuse only layout, spacing, colors, typography, icons, headings, breadcrumbs, and control appearance.
3. Prefer one scoped theme stylesheet over inline styles or replacing minified base-theme files. Reuse existing assets and icon libraries.
4. Edit markup and CSS only. Keep shared controls in `col-auto` wrappers and make the parent row responsive with wrapping.
5. Verify that code-behind and designer files are unchanged. Compare the recorded server-control contract with the final markup.
6. Test representative desktop, tablet, and mobile widths. Confirm no horizontal overflow, clipped shared controls, forced overlap, or action groups pushed outside the container.

## Completion checks

- Logic/code-behind/designer unchanged.
- Server-control IDs, types, events, bindings, validation, and postback settings unchanged.
- No feature from the visual sample was implemented without existing logic.
- Shared controls use `col-auto` or equivalent intrinsic sizing; no hard Bootstrap column width was introduced around them.
- Desktop/tablet/mobile layouts wrap cleanly and preserve the existing behavior.
