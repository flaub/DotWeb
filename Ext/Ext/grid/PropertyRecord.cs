using System;
using DotWeb.Core;

namespace Ext.grid {
    /// <summary>
    ///     /**
    ///     A specific {@link Ext.data.Record} type that represents a name/value pair and is made to work with the
    ///     {@link Ext.grid.PropertyGrid}.  Typically, PropertyRecords do not need to be created directly as they can be
    ///     created implicitly by simply using the appropriate data configs either via the {@link Ext.grid.PropertyGrid#source}
    ///     config property or by calling {@link Ext.grid.PropertyGrid#setSource}.  However, if the need arises, these records
    ///     can also be created explicitly as shwon below.  Example usage:
    ///     <pre><code>
    ///     var rec = new Ext.grid.PropertyRecord({
    ///     name: 'Birthday',
    ///     value: new Date(Date.parse('05/26/1972'))
    ///     });
    ///     // Add record to an already populated grid
    ///     grid.store.addSorted(rec);
    ///     </code></pre>
    /// </summary>
    /// <jssource>C:\home\src\external\ext-2.2\source\widgets\grid\PropertyGrid.js</jssource>
    [Native]
    public class PropertyRecord  {

        /// <summary>will be read automatically by the grid to determine the type of editor to use when displaying it.</summary>
        /// <returns></returns>
        public PropertyRecord() {}
        /// <summary>will be read automatically by the grid to determine the type of editor to use when displaying it.</summary>
        /// <param name="config">A data object in the format: {name: [name], value: [value]}.  The specified value's type</param>
        /// <returns></returns>
        public PropertyRecord(object config) {}

        /// <summary>The reference to the prototype the every object of this type is constructed with</summary>
        public static PropertyRecord prototype { get { return null; } set { } }

        /// <summary>The reference to the constructor function</summary>
        public static Delegate constructor { get { return null; } set { } }




    }
    [Anonymous]
    public class PropertyRecordConfig {

    }


}
