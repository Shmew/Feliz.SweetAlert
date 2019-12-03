namespace Feliz.SweetAlert

open Browser.Types
open Fable.Core
open Fable.Core.JsInterop
open System.ComponentModel

[<AutoOpen;EditorBrowsable(EditorBrowsableState.Never)>]
module Simple =
    let fire (title: string) (message: string) icon = 
        Bindings.swal.fire (createObj !![ swal.title title; swal.text message; icon ]) |> Promise.start

    let fireWithHandler (title: string) (message: string) icon handler = 
        Bindings.swal.fire (createObj !![ swal.title title; swal.text message; icon ]) |> Bindings.fireWrapper handler

    let fireWithHandlerIgnore (title: string) (message: string) icon handler = 
        Bindings.swal.fire (createObj !![ swal.title title; swal.text message; icon ]) |> Bindings.fireWrapperIgnore handler

[<Erase>]
type Swal =
    static member inline fire (options: ISwalProperty list) = 
        Bindings.swal.fire (createObj !!options) |> Promise.start

    static member inline fire (options: ISwalProperty list, handler: (SweetAlertResult<'T> -> unit)) = 
        Bindings.swal.fire (createObj !!options) |> Bindings.fireWrapperIgnore handler

    static member inline isVisible() = Bindings.swal.isVisible()
    static member inline update (options: ISwalProperty list) =
        Bindings.swal.update (createObj !!options)

    static member inline close (result: SweetAlertResult<'T>) = Bindings.swal.close (result |> Bindings.buildAlertResult)
    static member inline getPopup() = Bindings.swal.getPopup()
    static member inline getTitle() = Bindings.swal.getTitle()
    static member inline getProgressSteps() = Bindings.swal.getProgressSteps()
    static member inline getHtmlContainer() = Bindings.swal.getHtmlContainer()
    static member inline getImage() = Bindings.swal.getImage()
    static member inline getCloseButton() = Bindings.swal.getCloseButton()
    static member inline getIcon() = Bindings.swal.getIcon()
    static member inline getIcons() = Bindings.swal.getIcons()
    static member inline getConfirmButton() = Bindings.swal.getConfirmButton()
    static member inline getCancelButton() = Bindings.swal.getCancelButton()
    static member inline getActions() = Bindings.swal.getActions()
    static member inline getFooter() = Bindings.swal.getFooter()
    static member inline getFocusableElements() = Bindings.swal.getFocusableElements()
    static member inline enableButtons() = Bindings.swal.enableButtons()
    static member inline disableButtons() = Bindings.swal.disableButtons()
    static member inline showLoading() = Bindings.swal.showLoading()
    static member inline hideLoading() = Bindings.swal.hideLoading()
    static member inline isLoading() = Bindings.swal.isLoading()
    static member inline clickConfirm() = Bindings.swal.clickConfirm()
    static member inline clickCancel() = Bindings.swal.clickCancel()
    static member inline showValidationMessage (message: string) = Bindings.swal.showValidationMessage message
    static member inline resetValidationMessage() = Bindings.swal.resetValidationMessage()
    static member inline getInput() = Bindings.swal.getInput()
    static member inline disableInput() = Bindings.swal.disableInput()
    static member inline enableInput() = Bindings.swal.enableInput()
    static member inline getValidationMessage() = Bindings.swal.getValidationMessage()
    static member inline getTimerLeft() = Bindings.swal.getTimerLeft()
    static member inline stopTimer() = Bindings.swal.stopTimer()
    static member inline resumeTimer() = Bindings.swal.resumeTimer()
    static member inline toggleTimer() = Bindings.swal.toggleTimer()
    static member inline isTimerRunning() = Bindings.swal.isTimerRunning()
    static member inline increaseTimer (ms: int) = Bindings.swal.increaseTimer ms
    static member inline queue (steps: ISwalProperty list list) = 
        steps |> List.map (fun props -> (createObj !!props) |> U2.Case1) |> ResizeArray |> Bindings.swal.queue 
    static member inline getQueueStep() = Bindings.swal.getQueueStep()
    static member inline insertQueueStep (step: ISwalProperty list) = Bindings.swal.insertQueueStep (createObj !!step)
    static member inline insertQueueStep (step: ISwalProperty list, index: int) = Bindings.swal.insertQueueStep ((createObj !!step), index)
    static member inline deleteQueueStep (index: int) = Bindings.swal.deleteQueueStep index
    static member inline isValidParameter (paramName: string) = Bindings.swal.isValidParameter paramName
    static member inline isUpdatableParameter (paramName: string) = Bindings.swal.isUpdatableParameter paramName
    static member inline version () = Bindings.swal.version

module Swal =
    [<Erase>]
    type Simple =
        static member inline error (title: string, message: string) = Simple.fire title message swal.icon.error
        
        static member inline error (title: string, message: string, handler: (SweetAlertResult<'T> -> unit)) = 
            Simple.fireWithHandlerIgnore title message swal.icon.error handler

        static member inline info (title: string, message: string) = Simple.fire title message swal.icon.info
        
        static member inline info (title: string, message: string, handler: (SweetAlertResult<'T> -> unit)) = 
            Simple.fireWithHandlerIgnore title message swal.icon.error handler

        static member inline question (title: string, message: string) = Simple.fire title message swal.icon.question
        
        static member inline question (title: string, message: string, handler: (SweetAlertResult<'T> -> unit)) = 
            Simple.fireWithHandlerIgnore title message swal.icon.error handler

        static member inline success (title: string, message: string) = Simple.fire title message swal.icon.success
        
        static member inline success (title: string, message: string, handler: (SweetAlertResult<'T> -> unit)) = 
            Simple.fireWithHandlerIgnore title message swal.icon.error handler

        static member inline warning (title: string, message: string) = Simple.fire title message swal.icon.warning
        
        static member inline warning (title: string, message: string, handler: (SweetAlertResult<'T> -> unit)) = 
            Simple.fireWithHandlerIgnore title message swal.icon.error handler

module Cmd =
    open Elmish

    [<Erase>]
    type Swal =
        static member inline fire (options: ISwalProperty list) : Cmd<_> = 
            [ fun _ -> Bindings.swal.fire (createObj !!options) |> Promise.start ]
    
        static member inline fire (options: ISwalProperty list, handler: (SweetAlertResult<'T> -> 'a)) : Cmd<_> = 
            [ Bindings.swal.fire (createObj !!options) |> Bindings.fireWrapper handler ]
    
        static member inline isVisible() : Cmd<_> = [ (fun dispatch -> Bindings.swal.isVisible() |> dispatch) ]
        
        static member inline update (options: ISwalProperty list) : Cmd<_> =
            [ fun _ -> Bindings.swal.update (createObj !!options) ]
    
        static member inline close (result: SweetAlertResult<'T>) : Cmd<_> = 
            [ fun _ -> Bindings.swal.close (result |> Bindings.buildAlertResult) ]
        static member inline getPopup (handler: HTMLElement -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getPopup() |> handler ]
        
        static member inline getTitle (handler: HTMLElement -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getTitle() |> handler ]
        
        static member inline getProgressSteps (handler: HTMLElement -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getProgressSteps() |> handler ]
        
        static member inline getHtmlContainer (handler: HTMLElement -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getHtmlContainer() |> handler ]
        
        static member inline getImage (handler: HTMLElement -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getImage() |> handler ]
        
        static member inline getCloseButton (handler: HTMLElement -> unit) : Cmd<_> =[ fun _ ->  Bindings.swal.getCloseButton() |> handler ]
        
        static member inline getIcon (handler: HTMLElement option -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getIcon() |> handler ]
        
        static member inline getIcons (handler: HTMLElement list -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getIcons() |> List.ofSeq |> handler ]
        
        static member inline getConfirmButton (handler: HTMLElement -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getConfirmButton() |> handler ]
        
        static member inline getCancelButton (handler: HTMLElement -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getCancelButton() |> handler ]
        
        static member inline getActions (handler: HTMLElement -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getActions() |> handler ]
        
        static member inline getFooter (handler: HTMLElement -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getFooter() |> handler ]
        
        static member inline getFocusableElements (handler: HTMLElement list -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getFocusableElements() |> List.ofSeq |> handler ]
        
        static member inline enableButtons() : Cmd<_> = [ fun _ -> Bindings.swal.enableButtons() ]
        
        static member inline disableButtons() : Cmd<_> = [ fun _ -> Bindings.swal.disableButtons() ]
        
        static member inline showLoading() : Cmd<_> = [ fun _ -> Bindings.swal.showLoading() ]
        
        static member inline hideLoading() : Cmd<_> = [ fun _ -> Bindings.swal.hideLoading() ]
        
        static member inline isLoading (handler: bool -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.isLoading() |> handler ]
        
        static member inline clickConfirm() : Cmd<_> = [ fun _ -> Bindings.swal.clickConfirm() ]
        
        static member inline clickCancel() : Cmd<_> = [ fun _ -> Bindings.swal.clickCancel() ]
        
        static member inline showValidationMessage (message: string) : Cmd<_> = [ fun _ -> Bindings.swal.showValidationMessage message ]
        
        static member inline resetValidationMessage() : Cmd<_> = [ fun _ -> Bindings.swal.resetValidationMessage() ]
        
        static member inline getInput (handler: HTMLElement -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getInput() |> handler ]
        
        static member inline disableInput() : Cmd<_> = [ fun _ -> Bindings.swal.disableInput() ]
        
        static member inline enableInput() : Cmd<_> = [ fun _ -> Bindings.swal.enableInput() ]
        
        static member inline getValidationMessage (handler: HTMLElement -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getValidationMessage() |> handler ]
        
        static member inline getTimerLeft (handler: int option -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.getTimerLeft() |> handler ]
        
        static member inline stopTimer (handler: int option -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.stopTimer() |> handler ]
        
        static member inline resumeTimer (handler: int option -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.resumeTimer() |> handler ]
        
        static member inline toggleTimer (handler: int option -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.toggleTimer() |> handler ]
        
        static member inline isTimerRunning (handler: bool option -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.isTimerRunning() |> handler ]
        
        static member inline increaseTimer (ms: int, handler: int option -> unit) : Cmd<_> =
            [ fun _ -> Bindings.swal.increaseTimer ms |> handler ]
        
        static member inline queue (steps: ISwalProperty list list, handler: (SweetAlertResult<'T> -> 'a)) : Cmd<_> = 
            steps 
            |> List.map (fun props -> (createObj !!props) |> U2.Case1) 
            |> ResizeArray 
            |> Bindings.swal.queue 
            |> Bindings.fireWrapper handler 
            |> List.singleton

        static member inline getQueueStep (handler: string option -> unit) : Cmd<_> = 
            [ fun _ -> Bindings.swal.getQueueStep() |> handler ]

        static member inline insertQueueStep (step: ISwalProperty list, handler: int -> unit) : Cmd<_> = 
            [ fun _ -> Bindings.swal.insertQueueStep (createObj !!step) |> handler ]

        static member inline insertQueueStep (step: ISwalProperty list, index: int, handler: int -> unit) : Cmd<_> = 
            [ fun _ -> Bindings.swal.insertQueueStep ((createObj !!step), index) |> handler ]

        static member inline deleteQueueStep (index: int) : Cmd<_> = [ fun _ -> Bindings.swal.deleteQueueStep index ]

        static member inline isValidParameter (paramName: string, handler: bool -> unit) : Cmd<_> = [ fun _ -> Bindings.swal.isValidParameter paramName |> handler ]

        static member inline isUpdatableParameter (paramName: string, handler: bool -> unit)  : Cmd<_> = 
            [ fun _ -> Bindings.swal.isUpdatableParameter paramName |> handler ]
        static member inline version (handler: string -> unit)  = [ fun _ -> Bindings.swal.version |> handler ]
    
    module Swal =
        [<Erase>]
        type Simple =
            static member inline error (title: string, message: string) : Cmd<_> = 
                [ fun _ -> Simple.fire title message swal.icon.error ]

            static member inline error (title: string, message: string, handler: (SweetAlertResult<'T> -> 'a)) : Cmd<_> = 
                [ Simple.fireWithHandler title message swal.icon.error handler ]
    
            static member inline info (title: string, message: string) : Cmd<_> = 
                [ fun _ -> Simple.fire title message swal.icon.info ]

            static member inline info (title: string, message: string, handler: (SweetAlertResult<'T> -> 'a)) : Cmd<_> = 
                [ Simple.fireWithHandler title message swal.icon.error handler ]
    
            static member inline question (title: string, message: string) : Cmd<_> = 
                [ fun _ -> Simple.fire title message swal.icon.question ]

            static member inline question (title: string, message: string, handler: (SweetAlertResult<'T> -> 'a)) : Cmd<_> = 
                [ Simple.fireWithHandler title message swal.icon.error handler ]
    
            static member inline success (title: string, message: string) : Cmd<_> = 
                [ fun _ -> Simple.fire title message swal.icon.success ]

            static member inline success (title: string, message: string, handler: (SweetAlertResult<'T> -> 'a)) : Cmd<_> = 
                [ Simple.fireWithHandler title message swal.icon.error handler ]
    
            static member inline warning (title: string, message: string) : Cmd<_> = 
                [ fun _ -> Simple.fire title message swal.icon.warning ]

            static member inline warning (title: string, message: string, handler: (SweetAlertResult<'T> -> 'a)) : Cmd<_> = 
                [ Simple.fireWithHandler title message swal.icon.error handler ]