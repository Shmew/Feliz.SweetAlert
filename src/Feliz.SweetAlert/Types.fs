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

type SweetAlertResult<'T> =
    | ResultValue of 'T
    | DismissReason of DismissReason
    
[<Erase;RequireQualifiedAccess>]
module SweetAlertResult =
    let inline either (ofValue: 'T -> unit) (ofDismiss: DismissReason -> unit) (input: SweetAlertResult<'T>) =
        match input with
        | ResultValue res -> ofValue res
        | DismissReason dr -> ofDismiss dr

    let inline ofValue (handler: 'T -> unit) (input: SweetAlertResult<'T>) =
        either handler (fun _ -> ()) input

    let inline ofDismiss (handler: DismissReason -> unit) (input: SweetAlertResult<'T>) =
        either (fun _ -> ()) handler input

type IObservableLike<'T> =
    abstract toPromise: unit -> JS.Promise<'T>

[<AutoOpen;EditorBrowsable(EditorBrowsableState.Never);Erase>]
module Types =
    type ISwalProperty = interface end
    type ISwalUpdatableProperty = inherit ISwalProperty
    type ISwalCustomClassProperty = interface end
    type ISwalHideClassProperty = interface end
    type ISwalShowClassProperty = interface end
