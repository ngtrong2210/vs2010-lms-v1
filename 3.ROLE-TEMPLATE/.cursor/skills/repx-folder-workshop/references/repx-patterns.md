# REPX serialized patterns

DevExpress `.repx` files in this workflow are commonly C# serialization sources, not XML. Preserve the generated ordering and exact control names.

## Embedded script

Collect every quoted chunk from the declaration beginning with `string resourceString =` through its terminating semicolon. Concatenate the chunks, decode Base64, and inspect the decoded bytes/text for event handler bodies. Compare the Base64 payload hash for exact equality.

Synchronize handler source and control wiring together. A valid handler in `ScriptsSource` has no effect until the relevant control has, for example:

```csharp
this.someCell.Scripts.OnTextChanged = "cel1_TextChanged";
```

## Bound score cell

Prefer the canonical sample's binding form exactly. A common numeric score cell is:

```csharp
this.someCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
    new DevExpress.XtraReports.UI.XRBinding("Text", null, "Table.FinalSummary_15", "{0:n1}")});
this.someCell.Name = "someCell";
this.someCell.Scripts.OnTextChanged = "cel1_TextChanged";
this.someCell.Text = "someCell";
```

Do not combine that binding with `Text = "[Table.FinalSummary_15]"`; the expression can conflict with the binding. Expression variants such as `[Table.FinalSummary_15!n1]` also bypass `OnTextChanged` when no event wiring is present.

## Column-count changes

When adding or removing one subject, update the complete vertical slice:

- field declaration and instantiation when a new control is truly required;
- `Cells.AddRange` membership for detail and header rows;
- subject/unit header bindings or parameter bindings;
- score binding and event wiring;
- weight, size, and position values;
- formatting rules only when the canonical family makes them count-dependent.

Prefer the nearest valid count. Removing the final column from a higher-count template is usually safer than inventing a new control from a lower-count template.

## Layout properties

Report margins do not fully determine rendered whitespace. Keep these synchronized with the canonical sample when they are in scope:

- report `Margins`;
- `topMarginBand1.HeightF`;
- `bottomMarginBand1.HeightF`;
- `ReportFooter.HeightF`;
- page size, paper kind, and landscape mode.

## Structural checks

For every `XRTableCell` used in `Cells.AddRange`, require a declaration and instantiation. Check for missing/duplicate subject indexes, stale references beyond the intended count, balanced braces, extractable embedded resources, and event names that exist in the decoded script.
