namespace Feliz.SweetAlert

open System.ComponentModel

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
    
module SweetAlertResult =
    let either (ofValue: 'T -> unit) (ofDismiss: DismissReason -> unit) (input: SweetAlertResult<'T>) =
#if DEBUG
        Fable.Core.JS.console.log input
#endif
        match input with
        | ResultValue res -> ofValue res
        | DismissReason dr -> ofDismiss dr

    let ofValue (handler: 'T -> unit) (input: SweetAlertResult<'T>) =
        either handler (fun _ -> ()) input

    let ofDismiss (handler: DismissReason -> unit) (input: SweetAlertResult<'T>) =
        either (fun _ -> ()) handler input

[<AutoOpen;EditorBrowsable(EditorBrowsableState.Never)>]
module Types =
    type ISwalProperty = interface end
    type ISwalCustomClassProperty = interface end
    type ISwalHideClassProperty = interface end
    type ISwalShowClassProperty = interface end
    