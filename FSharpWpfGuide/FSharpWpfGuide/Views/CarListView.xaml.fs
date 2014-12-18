namespace FSharpWpfGuide.Views

type CarListView = FsXaml.XAML<"Views/CarListView.xaml", true>

type CarListViewController() =
    inherit FsXaml.UserControlViewController<CarListView>()

    let buttonClick (parent : CarListView) _ =
        let msg txt = System.Windows.MessageBox.Show(txt) |> ignore
        match parent.CarList.SelectedItem with
        | :? FSharpWpfGuide.ViewModels.CarViewModel as x ->
            sprintf "Hello. You've selected the %s %s" x.MakeStr x.Model
            |> msg
        | _ -> msg "Hi. You haven't selected a car yet."

    override self.OnInitialized view =
        view.TestButton.Click.Subscribe (buttonClick view) |> self.DisposeOnUnload
