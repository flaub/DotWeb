using System;
using DotWeb.Client;

namespace Ext {
	/// <summary>
	///     /**
	///     Simple class that can provide a shadow effect for any element.  Note that the element MUST be absolutely positioned,
	///     and the shadow does not provide any shimming.  This should be used only in simple cases -- for more advanced
	///     functionality that can also provide the same shadow effect, see the {@link Ext.Layer} class.
	/// </summary>
	/// <jssource>C:\home\src\proto\DotWeb\ExtJsParser\ext-2.2\source\widgets\Shadow.js</jssource>
	public class Shadow : DotWeb.Client.JsNativeBase {

		/// <summary>Create a new Shadow</summary>
		/// <returns></returns>
		public Shadow() { C_(); }
		/// <summary>Create a new Shadow</summary>
		/// <param name="config">The config object</param>
		/// <returns></returns>
		public Shadow(object config) { C_(config); }

		/// <summary></summary>
		/// <summary>The reference to the prototype the every object of this type is constructed with</summary>
		public static Shadow prototype { get { return S_<Shadow>(); } set { S_(value); } }

		/// <summary>The reference to the constructor function</summary>
		public static Delegate constructor { get { return S_<Delegate>(); } set { S_(value); } }

		/// <summary>
		///     The shadow display mode.  Supports the following options:<br />
		///     sides: Shadow displays on both sides and bottom only<br />
		///     frame: Shadow displays equally on all four sides<br />
		///     drop: Traditional bottom-right drop shadow (default)
		/// </summary>
		public System.String mode { get { return _<System.String>(); } set { _(value); } }

		/// <summary>The number of pixels to offset the shadow from the element (defaults to 4)</summary>
		public System.String offset { get { return _<System.String>(); } set { _(value); } }


		/// <summary>Displays the shadow under the target element</summary>
		/// <returns></returns>
		public virtual void show() { _(); }

		/// <summary>Displays the shadow under the target element</summary>
		/// <param name="targetEl">The id or element under which the shadow should display</param>
		/// <returns></returns>
		public virtual void show(object targetEl) { _(targetEl); }

		/// <summary>Returns true if the shadow is visible, else false</summary>
		/// <returns></returns>
		public virtual void isVisible() { _(); }

		/// <summary>
		///     Direct alignment when values are already available. Show must be called at least once before
		///     calling this method to ensure it is initialized.
		/// </summary>
		/// <returns></returns>
		public virtual void realign() { _(); }

		/// <summary>
		///     Direct alignment when values are already available. Show must be called at least once before
		///     calling this method to ensure it is initialized.
		/// </summary>
		/// <param name="left">The target element left position</param>
		/// <returns></returns>
		public virtual void realign(double left) { _(left); }

		/// <summary>
		///     Direct alignment when values are already available. Show must be called at least once before
		///     calling this method to ensure it is initialized.
		/// </summary>
		/// <param name="left">The target element left position</param>
		/// <param name="top">The target element top position</param>
		/// <returns></returns>
		public virtual void realign(double left, double top) { _(left, top); }

		/// <summary>
		///     Direct alignment when values are already available. Show must be called at least once before
		///     calling this method to ensure it is initialized.
		/// </summary>
		/// <param name="left">The target element left position</param>
		/// <param name="top">The target element top position</param>
		/// <param name="width">The target element width</param>
		/// <returns></returns>
		public virtual void realign(double left, double top, double width) { _(left, top, width); }

		/// <summary>
		///     Direct alignment when values are already available. Show must be called at least once before
		///     calling this method to ensure it is initialized.
		/// </summary>
		/// <param name="left">The target element left position</param>
		/// <param name="top">The target element top position</param>
		/// <param name="width">The target element width</param>
		/// <param name="height">The target element height</param>
		/// <returns></returns>
		public virtual void realign(double left, double top, double width, double height) { _(left, top, width, height); }

		/// <summary>Hides this shadow</summary>
		/// <returns></returns>
		public virtual void hide() { _(); }

		/// <summary>Adjust the z-index of this shadow</summary>
		/// <returns></returns>
		public virtual void setZIndex() { _(); }

		/// <summary>Adjust the z-index of this shadow</summary>
		/// <param name="zindex">The new z-index</param>
		/// <returns></returns>
		public virtual void setZIndex(double zindex) { _(zindex); }



	}

	[JsAnonymous]
	public class ShadowConfig : DotWeb.Client.JsAccessible {
		/// <summary>  The shadow display mode.  Supports the following options:<br /> sides: Shadow displays on both sides and bottom only<br /> frame: Shadow displays equally on all four sides<br /> drop: Traditional bottom-right drop shadow (default)</summary>
		public System.String mode { get; set; }

		/// <summary>  The number of pixels to offset the shadow from the element (defaults to 4)</summary>
		public System.String offset { get; set; }

	}
}
