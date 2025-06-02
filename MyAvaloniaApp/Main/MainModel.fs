namespace MyAvaloniaApp.Main

open MyAvaloniaApp.Domains

type Model =
    { Counter: Counter.Model
      Todo: Todo.Model }