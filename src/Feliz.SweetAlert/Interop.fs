namespace Feliz.SweetAlert

open Fable.Core

[<Erase;RequireQualifiedAccess>]
module Interop =
    let inline mkSwalAttr (key: string) (value: obj) : ISwalProperty = unbox (key, value)
    let inline mkSwalCustomClassAttr (key: string) (value: obj) : ISwalCustomClassProperty = unbox (key, value)
    let inline mkSwalHideClassAttr (key: string) (value: obj) : ISwalHideClassProperty = unbox (key, value)
    let inline mkSwalShowClassAttr (key: string) (value: obj) : ISwalShowClassProperty = unbox (key, value)
    