namespace MyAvaloniaApp.Main

open MyAvaloniaApp.Domains

type Msg =
    | CounterMsg of Counter.Msg
    | TodoMsg of Todo.Msg