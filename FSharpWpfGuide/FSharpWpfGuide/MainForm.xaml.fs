namespace FSharpWpfGuide.Views

type MainForm = FsXaml.XAML<"MainForm.xaml", true>

namespace FSharpWpfGuide.ViewModels

type MainFormViewModel() =
    member __.Title = "F# |> WPF Guide"
