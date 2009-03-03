using System;
using Ext.form;

namespace Ext {
    public delegate void AnonymousDelegate();
    public delegate void GenericOneArgDelegate(object arg1);
    public delegate void GenericTwoArgDelegate(object arg1, object arg2);
    public delegate void GenericThreeArgDelegate(object arg1, object arg2, object arg3);

    public delegate void MessageBoxResponseDelegate(string button, string text);

    public delegate void FormSubmitDelegate(FormPanel form, Ext.form.ActionClass action);
}
