///////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2005-2016 Laszlo Arvai. All rights reserved.
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software Foundation,
// Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301  USA
///////////////////////////////////////////////////////////////////////////////
// File description
// ----------------
// String chunk handling class
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Windows.Forms;

namespace DominoResourceFileViewer
{
	/// <summary>
	/// String chunk handling class
	/// </summary>
  public class chkString : chkChunkBase
	{
		#region � Data members �
		private byte[] m_buffer;						/// Chunk binary buffer
    private int m_offset;								/// offset of the chunk
    private frmString m_display_form;		/// Form used to display chunk data
    private UInt32 m_chunk_id;					/// ID of the chunk
		#endregion

		#region � Constructor �

		/// Default constructor
		public chkString()
    {
      m_display_form = null;
    }
		#endregion

		#region � Load function �

		/// <summary>
		/// Loads binary chunk
		/// </summary>
		/// <param name="in_chunk_id">ID of the chunk</param>
		/// <param name="in_buffer">buffer contains the whiole chunk</param>
		/// <param name="in_offset">Offset of the chunk within the resource file</param>
		/// <returns>True is success</returns>
		public override bool Load(UInt32 in_chunk_id, byte[] in_buffer, int in_offset)
    {
      // load data
      m_buffer = in_buffer;
      m_chunk_id = in_chunk_id;
      m_offset = in_offset;

      return true;
    }
		#endregion

		#region � Chunk GUI handling �

		/// <summary>
		/// Adds chunk to the tree control
		/// </summary>
		/// <param name="in_treeview">Tree control</param>
		/// <param name="in_chunk_index">Index of the chunk within the file</param>
		public override void AddToTreeControl(TreeView in_treeview, int in_chunk_index)
    {
       in_treeview.Nodes.Add(in_chunk_index.ToString(), "String (0x" + m_offset.ToString("X8") + ")", 2, 2);
    }

    /// <summary>
    /// Gets display panels
    /// </summary>
    /// <param name="in_path">Path of the display panel</param>
    /// <returns>Panel to display</returns>
		public override Panel GetDisplayPanel(string in_path)
    {
      m_display_form = new frmString();

      return m_display_form.FillControls(m_buffer);
    }


    /// <summary>
    /// Releases current display panel/form
    /// </summary>
		public override void ReleaseDisplayForm()
    {
      if (m_display_form != null)
        m_display_form.Dispose();

      m_display_form = null;
		}
		#endregion
	}
}
