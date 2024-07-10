#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.Alarm;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.WebUI;
using FTOptix.Recipe;
using FTOptix.EventLogger;
using FTOptix.DataLogger;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.System;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.Core;
#endregion

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        Log.Info("progetto avviato!");
        myPeriodicTask = new PeriodicTask(IncrementVariable, 1000, LogicObject);
        myPeriodicTask.Start();
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        Log.Info("progetto arrestato!");
        myPeriodicTask.Dispose();
    }

    [ExportMethod]
    public void LogInput(string testo)
    {
        Log.Info(testo);
    }

    private void IncrementVariable()
    {
        var variable1 = Project.Current.GetVariable("Model/VariabiliCreateDaScript/Variabile0");
        variable1.Value = variable1.Value + 1;
    }

    private PeriodicTask myPeriodicTask;
}
