namespace Feliz.SweetAlert

open Fable.Core
open System.ComponentModel

[<StringEnum>]
type DismissReason =
    /// The user clicked the backdrop.
    | Backdrop
    /// The user clicked the cancel button.
    | Cancel
    /// The user clicked the close button.
    | Close
    /// The user hit the Esc key.
    | Esc
    /// The timer ran out, and the alert closed automatically.
    | Timer

[<RequireQualifiedAccess>]
module SweetAlert =
    [<RequireQualifiedAccess>]
    type Result<'T> =
        | Value of 'T
        | Denied
        | Dismissal of DismissReason

    [<Erase;RequireQualifiedAccess>]
    module Result =
        let inline any (ofValue: 'T -> unit) (ofDenied: unit -> unit) (ofDismissal: DismissReason -> unit) (input: Result<'T>) =
            match input with
            | Result.Value res -> ofValue res
            | Result.Denied -> ofDenied()
            | Result.Dismissal dr -> ofDismissal dr

        let inline ofValue (handler: 'T -> unit) (input: Result<'T>) =
            any handler ignore ignore input

        let inline ofDenied (handler: unit -> unit) (input: Result<'T>) =
            any ignore handler ignore input

        let inline ofDismissal (handler: DismissReason -> unit) (input: Result<'T>) =
            any ignore ignore handler input

type IObservableLike<'T> =
    abstract toPromise: unit -> JS.Promise<'T>

[<AutoOpen;EditorBrowsable(EditorBrowsableState.Never);Erase>]
module Types =
    type ISwalProperty = interface end
    type ISwalUpdatableProperty = inherit ISwalProperty
    type ISwalCustomClassProperty = interface end
    type ISwalHideClassProperty = interface end
    type ISwalShowClassProperty = interface end
