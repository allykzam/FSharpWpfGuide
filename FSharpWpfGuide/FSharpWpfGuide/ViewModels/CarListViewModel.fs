namespace FSharpWpfGuide.ViewModels

open FSharpWpfGuide

type CarListViewModel() =
    inherit FSharp.ViewModule.ViewModelBase()

    let cars = System.Collections.ObjectModel.ObservableCollection<CarViewModel>()

    do
        cars.Add(new CarViewModel())
        cars.Add(new CarViewModel({ Make = Models.Chevy; Model = "Camaro ZL1"; Year = 2015; Miles = 10; }))

    member __.Cars with get () = cars
