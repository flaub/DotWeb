using System;
using System.DotWeb;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Simple class that can provide a shadow effect for any element.  Note that the element MUST be absolutely positioned,
	///     and the shadow does not provide any shimming.  This should be used only in simple cases -- for more advanced
	///     functionality that can also provide the same shadow effect, see the {@link Ext.Layer} class.
	/// </summary>
	/// <jssource>F:\src\git\DotWeb\proxy\ExtJsParser\ext-2.2\source\widgets\Shadow.js</jssource>
	public class Shadow : System.DotWeb.JsObject {

		/// <summary>Create a new Shadow</summary>
		/// <returns></returns>
		public extern Shadow();
		/// <summary>Create a new Shadow</summary>
		/// <param name="config">The config object</param>
		/// <returns></returns>
		public extern Shadow(object config);

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public extern static Shadow prototype { get; set; }

		/// <summary>The reference to the constructor function</summary>
		public extern static Delegate constructor { get; set; }

		/// <summary>
		///     The shadow display mode.  Supports the following options:<br />
		///     sides: Shadow displays on both sides and bottom only<br />
		///     frame: Shadow displays equally on all four sides<br />
		///     drop: Traditional bottom-right drop shadow (default)
		/// </summary>
		public extern string mode { get; set; }

		/// <summary>The number of pixels to offset the shadow from the element (defaults to 4)</summary>
		public extern string offset { get; set; }


		/// <summary>Displays the shadow under the target element</summary>
		/// <returns></returns>
		public extern virtual void show();

		/// <summary>Displays the shadow under the target element</summary>
		/// <param name="targetEl">The id or element under which the shadow should display</param>
		/// <returns></returns>
		public extern virtual void show(object targetEl);

		/// <summary>Returns true if the shadow is visible, else false</summary>
		/// <returns></returns>
		public extern virtual void isVisible();

		/// <summary>
		///     Direct alignment when values are already available. Show must be called at least once before
		///     calling this method to ensure it is initialized.
		/// </summary>
		/// <returns></returns>
		public extern virtual void realign();

		/// <summary>
		///     Direct alignment when values are already available. Show must be called at least once before
		///     calling this method to ensure it is initialized.
		/// </summary>
		/// <param name="left">The target element left position</param>
		/// <returns></returns>
		public extern virtual void realign(double left);

		/// <summary>
		///     Direct alignment when values are already available. Show must be called at least once before
		///     calling this method to ensure it is initialized.
		/// </summary>
		/// <param name="left">The target element left position</param>
		/// <param name="top">The target element top position</param>
		/// <returns></returns>
		public extern virtual void realign(double left, double top);

		/// <summary>
		///     Direct alignment when values are already available. Show must be called at least once before
		///     calling this method to ensure it is initialized.
		/// </summary>
		/// <param name="left">The target element left position</param>
		/// <param name="top">The target element top position</param>
		/// <param name="width">The target element width</param>
		/// <returns></returns>
		public extern virtual void realign(double left, double top, double width);

		/// <summary>
		///     Direct alignment when values are already available. Show must be called at least once before
		///     calling this method to ensure it is initialized.
		/// </summary>
		/// <param name="left">The target element left position</param>
		/// <param name="top">The target element top position</param>
		/// <param name="width">The target element width</param>
		/// <param name="height">The target element height</param>
		/// <returns></returns>
		public extern virtual void realign(double left, double top, double width, double height);

		/// <summary>Hides this shadow</summary>
		/// <returns></returns>
		public extern virtual void hide();

		/// <summary>Adjust the z-index of this shadow</summary>
		/// <returns></returns>
		public extern virtual void setZIndex();

		/// <summary>Adjust the z-index of this shadow</summary>
		/// <param name="zindex">The new z-index</param>
		/// <returns></returns>
		public extern virtual void setZIndex(double zindex);



	}

	[JsAnonymous]
	public class ShadowConfig : System.DotWeb.JsDynamic {
		/// <summary>  The shadow display mode.  Supports the following options:<br /> sides: Shadow displays on both sides and bottom only<br /> frame: Shadow displays equally on all four sides<br /> drop: Traditional bottom-right drop shadow (default)</summary>
		public string mode { get { return (string)this["mode"]; } set { this["mode"] = value; } }

		/// <summary>  The number of pixels to offset the shadow from the element (defaults to 4)</summary>
		public string offset { get { return (string)this["offset"]; } set { this["offset"] = value; } }

	}
}
