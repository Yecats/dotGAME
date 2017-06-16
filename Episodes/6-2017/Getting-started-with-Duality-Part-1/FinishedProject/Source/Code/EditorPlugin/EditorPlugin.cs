using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duality.Editor;

namespace DotGame.Editor
{
	/// <summary>
	/// Defines a Duality editor plugin.
	/// </summary>
    public class DotGameEditorPlugin : EditorPlugin
	{
		public override string Id
		{
			get { return "DotGameEditorPlugin"; }
		}
	}
}
