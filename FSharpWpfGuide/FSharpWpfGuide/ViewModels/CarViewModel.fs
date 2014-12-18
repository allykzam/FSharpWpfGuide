namespace FSharpWpfGuide.ViewModels

open FSharpWpfGuide

type CarViewModel (vehicle : Models.Car) as self =
    inherit FSharp.ViewModule.ViewModelBase()

    let mutable car = vehicle
    let milesToDrive = self.Factory.Backing(<@ self.MilesInput @>, 0)

    let drive () =
        let miles = milesToDrive.Value
        if (miles < 0) then invalidArg "miles" "Cannot drive a negative number of miles"
        let newMiles = miles + car.Miles
        car <- { car with Miles = newMiles }
        self.RaisePropertyChanged <@ self.Miles @>

    let driveCommand =
        self.Factory.CommandSyncChecked(
            drive,
            (fun () -> milesToDrive.Value > 0),
            [ <@ self.MilesInput @> ]
            )

    do
        self.DependencyTracker.AddPropertyDependency(
            <@ self.MilesInputText @>,
            <@ self.MilesInput @>
            )

    new() =
        CarViewModel
            ({
                Make = Models.Ford;
                Model = "Mustang GT";
                Year = 2001;
                Miles = 10;
            })

    member __.Make with get () = car.Make
    member __.MakeStr
        with get () =
            match car.Make with
            | Models.Ford -> "Ford"
            | Models.Chevy -> "Chevy"
    member __.Model with get () = car.Model
    member __.Miles with get () = car.Miles
    member __.Drive with get () = driveCommand

    member __.MilesInput
        with get () = milesToDrive.Value
        and set value =
            milesToDrive.Value <- value
    member __.MilesInputText with get () = sprintf "Drive %i miles" milesToDrive.Value
