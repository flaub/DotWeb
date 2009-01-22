using System;
using H8.Support;

namespace Ext {
    /// <summary>
    ///     /**
    ///     A static {@link Ext.util.TaskRunner} instance that can be used to start and stop arbitrary tasks.  See
    ///     {@link Ext.util.TaskRunner} for supported methods and task config properties.
    ///     <pre><code>
    ///     // Start a simple clock task that updates a div once per second
    ///     var task = {
    ///     run: function(){
    ///     Ext.fly('clock').update(new Date().format('g:i:s A'));
    ///     },
    ///     interval: 1000 //1 second
    ///     }
    ///     Ext.TaskMgr.start(task);
    ///     </code></pre>
    ///     */
    ///     Ext.TaskMgr = new Ext.util.TaskRunner();
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\util\TaskMgr.js</jssource>
    [Native]
    public class TaskMgr  {

        /// <summary>Auto-generated default constructor</summary>
        /// <returns></returns>
        public TaskMgr() {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static TaskMgr prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }




    }
    [Anonymous]
    public class TaskMgrConfig {

    }


}
