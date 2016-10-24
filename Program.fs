// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

namespace LogPoc

open System
open Serilog
open Serilog.Sinks.RollingFile
open Serilog.Sinks.Observable
open Serilog.Sinks

module Log =
  let setupLogger () =
    Log.Logger <- (new LoggerConfiguration())
                  .MinimumLevel.Debug()
                  .WriteTo.LiterateConsole()
                  .WriteTo.RollingFile("c:\\dev\\LogPoc\\prog.log")
                  .CreateLogger();

  let logInfo msg =
    Serilog.Log.Information ( msg )

  let logError msg =
    Serilog.Log.Error ( msg )

  let logException ( ex : Exception ) =
    Serilog.Log.Error  ( ex.Message )

  let logClose () =
    Serilog.Log.CloseAndFlush()

module Program =
  open Log

  [<EntryPoint>]
  let main argv = 
    setupLogger ()
    logInfo "Logging Info"
    logError "Logging Error"
    logException (new Exception("Logging Exception"))
    //raise <|  System.OutOfMemoryException("Hey exception thrown.")
    Environment.FailFast("Failing fast")
    logClose ()


    Console.ReadKey() |> ignore
    0 // return an integer exit code
