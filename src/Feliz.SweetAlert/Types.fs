namespace Feliz.SweetAlert

open System.ComponentModel

type DismissReason =
    | Backdrop
    | Cancel
    | Close
    | Esc
    | Timer

type SweetAlertResult<'T> =
    | ResultValue of 'T
    | DismissReason of DismissReason

[<AutoOpen;EditorBrowsable(EditorBrowsableState.Never)>]
module Types =
    type ISwalProperty = interface end
    type ISwalCustomClassProperty = interface end
    type ISwalHideClassProperty = interface end
    type ISwalShowClassProperty = interface end
    