using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ImGuiNET.Extras;

public partial class TextEditor : IDisposable
{
	IntPtr NativePtr;

	public TextEditor()
	{
		NativePtr = igteNative.TextEditorTextEditor();
	}

	public void Dispose()
	{
		igteNative.TextEditorDestroy(NativePtr);
		NativePtr = IntPtr.Zero;
	}

	public unsafe ColorPalette Palette
	{
		get
		{
			var data = igteNative.IgteGetPalette(NativePtr);
			var l = (int)PaletteIndex.Max;
			var source = new uint[l];
			for (int i = 0; i < l; i++)
			{
				source[i] = data[i];
			}

			return new ColorPalette(source);
		}
		set
		{
			var l = (int)PaletteIndex.Max;
			uint* data = stackalloc uint[l];
			for (int i = 0; i < l; i++)
			{
				data[i] = value[i];
			}
			igteNative.IgteSetPalette(NativePtr, data);
		}
	}

	public unsafe void Render(string title, Vector2 size = default, bool border = false)
	{
		byte* native_name;
		int name_byteCount = 0;
		if (title != null)
		{
			name_byteCount = Encoding.UTF8.GetByteCount(title);
			if (name_byteCount > Util.StackAllocationSizeLimit)
			{
				native_name = Util.Allocate(name_byteCount + 1);
			}
			else
			{
				byte* native_name_stackBytes = stackalloc byte[name_byteCount + 1];
				native_name = native_name_stackBytes;
			}
			int native_name_offset = Util.GetUtf8(title, native_name, name_byteCount);
			native_name[native_name_offset] = 0;
		}
		else { native_name = null; }

		igteNative.IgteRender(NativePtr, native_name, size, border);

		if (name_byteCount > Util.StackAllocationSizeLimit)
		{
			Util.Free(native_name);
		}
	}

	public unsafe IEnumerable<string> TextLines
	{
		get
		{
			var count = TotalLines;
			var ret = new string[count];
			var arr = igteNative.IgteGetTextLines(NativePtr);

			for (int i = 0; i < count; i++)
			{
				var nat = arr[i];
				ret[i] = Util.StringFromPtr(nat);
				igteNative.IgteDeleteArray(nat);
			}

			igteNative.IgteDeleteArray(arr);
			return ret.ToList().AsReadOnly();
		}
		set
		{
			var array = value.ToArray();
			var count = array.Length;
			var data = (byte**)Marshal.AllocHGlobal(count * sizeof(byte*));

			for (int i = 0; i < count; i++)
			{
				byte* native_name;
				int name_byteCount = 0;
				var val = array[i];
				if (val != null)
				{
					name_byteCount = Encoding.UTF8.GetByteCount(val);
					native_name = Util.Allocate(name_byteCount + 1);
					int native_name_offset = Util.GetUtf8(val, native_name, name_byteCount);
					native_name[native_name_offset] = 0;
				}
				else { native_name = null; }

				data[i] = native_name;
			}

			igteNative.IgteSetTextLines(NativePtr, data, count);

			for (int i = 0; i < count; i++)
			{
				Marshal.FreeHGlobal((IntPtr)data[i]);
			}

			Marshal.FreeHGlobal((IntPtr)data);
		}
	}

	public unsafe string Text
	{
		get
		{
			var nat = igteNative.IgteGetText(NativePtr);
			var ret = Util.StringFromPtr(nat);
			igteNative.IgteDeleteArray(nat);
			return ret;
		}
		set
		{
			byte* native_name;
			int name_byteCount = 0;
			if (value != null)
			{
				name_byteCount = Encoding.UTF8.GetByteCount(value);
				if (name_byteCount > Util.StackAllocationSizeLimit)
				{
					native_name = Util.Allocate(name_byteCount + 1);
				}
				else
				{
					byte* native_name_stackBytes = stackalloc byte[name_byteCount + 1];
					native_name = native_name_stackBytes;
				}
				int native_name_offset = Util.GetUtf8(value, native_name, name_byteCount);
				native_name[native_name_offset] = 0;
			}
			else { native_name = null; }

			igteNative.IgteSetText(NativePtr, native_name);

			if (name_byteCount > Util.StackAllocationSizeLimit)
			{
				Util.Free(native_name);
			}
		}
	}

	public unsafe string SelectedText
	{
		get
		{
			var nat = igteNative.IgteGetSelectedText(NativePtr);
			var ret = Util.StringFromPtr(nat);
			igteNative.IgteDeleteArray(nat);
			return ret;
		}
	}

	public unsafe string CurrentLineText
	{
		get
		{
			var nat = igteNative.IgteGetCurrentLineText(NativePtr);
			var ret = Util.StringFromPtr(nat);
			igteNative.IgteDeleteArray(nat);
			return ret;
		}
	}

	public int TotalLines => igteNative.IgteGetTotalLines(NativePtr);

	public bool Overwrite => igteNative.IgteIsOverwrite(NativePtr);

	public bool ReadOnly
	{
		get => igteNative.IgteIsReadOnly(NativePtr);
		set => igteNative.IgteSetReadOnly(NativePtr, value);
	}

	public bool TextChanged => igteNative.IgteIsTextChanged(NativePtr);

	public bool CursorPositionChanged => igteNative.IgteIsCursorPositionChanged(NativePtr);

	public unsafe Coordinates CursorPosition
	{
		get
		{
			Coordinates ret = default;
			igteNative.IgteGetCursorPosition(NativePtr, &ret);
			return ret;
		}
		set => igteNative.IgteSetCursorPosition(NativePtr, value); 
	}

	public unsafe void InsertText(string aValue)
	{
		byte* native_name;
		int name_byteCount = 0;
		if (aValue != null)
		{
			name_byteCount = Encoding.UTF8.GetByteCount(aValue);
			if (name_byteCount > Util.StackAllocationSizeLimit)
			{
				native_name = Util.Allocate(name_byteCount + 1);
			}
			else
			{
				byte* native_name_stackBytes = stackalloc byte[name_byteCount + 1];
				native_name = native_name_stackBytes;
			}
			int native_name_offset = Util.GetUtf8(aValue, native_name, name_byteCount);
			native_name[native_name_offset] = 0;
		}
		else { native_name = null; }

		igteNative.IgteInsertText(NativePtr, native_name);

		if (name_byteCount > Util.StackAllocationSizeLimit)
		{
			Util.Free(native_name);
		}
	}

	public void MoveUp(int aAmount = 1, bool aSelect = false)
	{
		igteNative.IgteMoveUp(NativePtr, aAmount, aSelect);
	}
	public void MoveDown(int aAmount = 1, bool aSelect = false)
	{
		igteNative.IgteMoveDown(NativePtr, aAmount, aSelect);
	}
	public void MoveLeft(int aAmount = 1, bool aSelect = false, bool aWordMode = false)
	{
		igteNative.IgteMoveLeft(NativePtr, aAmount, aSelect, aWordMode);
	}
	public void MoveRight(int aAmount = 1, bool aSelect = false, bool aWordMode = false)
	{
		igteNative.IgteMoveRight(NativePtr, aAmount, aSelect, aWordMode);
	}
	public void MoveTop(bool aSelect = false)
	{
		igteNative.IgteMoveTop(NativePtr, aSelect);
	}
	public void MoveBottom(bool aSelect = false)
	{
		igteNative.IgteMoveBottom(NativePtr, aSelect);
	}
	public void MoveHome(bool aSelect = false)
	{
		igteNative.IgteMoveHome(NativePtr, aSelect);
	}
	public void MoveEnd(bool aSelect = false)
	{
		igteNative.IgteMoveEnd(NativePtr, aSelect);
	}

	public void SetSelectionStart(Coordinates aPosition)
	{
		igteNative.IgteSetSelectionStart(NativePtr, aPosition);
	}
	public void SetSelectionEnd(Coordinates aPosition)
	{
		igteNative.IgteSetSelectionEnd(NativePtr, aPosition);
	}
	public void SetSelection(Coordinates aStart, Coordinates aEnd, SelectionMode aMode = SelectionMode.Normal)
	{
		igteNative.IgteSetSelection(NativePtr, aStart, aEnd, aMode);
	}
	public void SelectWordUnderCursor()
	{
		igteNative.IgteSelectWordUnderCursor(NativePtr);
	}
	public void SelectAll()
	{
		igteNative.IgteSelectAll(NativePtr);
	}
	public bool HasSelection => igteNative.IgteHasSelection(NativePtr);
	public void Copy()
	{
		igteNative.IgteCopy(NativePtr);
	}

	public void Cut()
	{
		igteNative.IgteCut(NativePtr);
	}

	public void Paste()
	{
		igteNative.IgtePaste(NativePtr);
	}

	public void Delete()
	{
		igteNative.IgteDelete(NativePtr);
	}

	public bool CanUndo => igteNative.IgteCanUndo(NativePtr);

	public bool CanRedo => igteNative.IgteCanRedo(NativePtr);

	public void Undo(int aSteps = 1)
	{
		igteNative.IgteUndo(NativePtr, aSteps);
	}

	public void Redo(int aSteps = 1)
	{
		igteNative.IgteRedo(NativePtr, aSteps);
	}
}
