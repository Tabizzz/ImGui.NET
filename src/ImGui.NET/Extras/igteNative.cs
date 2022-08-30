using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using static ImGuiNET.Extras.TextEditor;

namespace ImGuiNET.Extras;

public unsafe class igteNative
{
	[DllImport("cimgui", EntryPoint = "Breakpoint_Breakpoint", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr BreakpointBreakpoint();

	[DllImport("cimgui", EntryPoint = "Breakpoint_Destroy", CallingConvention = CallingConvention.Cdecl)]
	public static extern void BreakpointDestroy(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "Coordinates_Coordinates", CallingConvention = CallingConvention.Cdecl)]
	public static extern Coordinates* CoordinatesCoordinates();

	[DllImport("cimgui", EntryPoint = "Coordinates_Destroy", CallingConvention = CallingConvention.Cdecl)]
	public static extern void CoordinatesDestroy(Coordinates* ins);

	[DllImport("cimgui", EntryPoint = "Identifier_Identifier", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr IdentifierIdentifier(sbyte* aDeclaration);

	[DllImport("cimgui", EntryPoint = "Identifier_Destroy", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IdentifierDestroy(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "Glyph_Glyph", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr GlyphGlyph(sbyte aChar, PaletteIndex aColorIndex);

	[DllImport("cimgui", EntryPoint = "Glyph_Destroy", CallingConvention = CallingConvention.Cdecl)]
	public static extern void GlyphDestroy(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "TextEditor_TextEditor", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr TextEditorTextEditor();

	[DllImport("cimgui", EntryPoint = "TextEditor_Destroy", CallingConvention = CallingConvention.Cdecl)]
	public static extern void TextEditorDestroy(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteGetPalette", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint* IgteGetPalette(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteSetPalette", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteSetPalette(IntPtr ins, uint* aValue);

	[DllImport("cimgui", EntryPoint = "igteRender", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteRender(IntPtr ins, byte* aTitle, Vector2 aSize, bool aBorder);

	[DllImport("cimgui", EntryPoint = "igteSetText", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteSetText(IntPtr ins, byte* aText);

	[DllImport("cimgui", EntryPoint = "igteSetTextLines", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteSetTextLines(IntPtr ins, byte** aLines, int aCount);

	[DllImport("cimgui", EntryPoint = "igteGetText", CallingConvention = CallingConvention.Cdecl)]
	public static extern byte* IgteGetText(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteGetTextLines", CallingConvention = CallingConvention.Cdecl)]
	public static extern byte** IgteGetTextLines(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteGetTextLinesSize", CallingConvention = CallingConvention.Cdecl)]
	public static extern ulong IgteGetTextLinesSize(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteGetSelectedText", CallingConvention = CallingConvention.Cdecl)]
	public static extern byte* IgteGetSelectedText(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteGetCurrentLineText", CallingConvention = CallingConvention.Cdecl)]
	public static extern byte* IgteGetCurrentLineText(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteGetTotalLines", CallingConvention = CallingConvention.Cdecl)]
	public static extern int IgteGetTotalLines(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteIsOverwrite", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool IgteIsOverwrite(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteSetReadOnly", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteSetReadOnly(IntPtr ins, bool aValue);

	[DllImport("cimgui", EntryPoint = "igteIsReadOnly", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool IgteIsReadOnly(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteIsTextChanged", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool IgteIsTextChanged(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteIsCursorPositionChanged", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool IgteIsCursorPositionChanged(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteGetCursorPosition", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteGetCursorPosition(IntPtr ins, Coordinates* aResult);

	[DllImport("cimgui", EntryPoint = "igteSetCursorPosition", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteSetCursorPosition(IntPtr ins, Coordinates aPosition);

	[DllImport("cimgui", EntryPoint = "igteInsertText", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteInsertText(IntPtr ins, byte* aValue);

	[DllImport("cimgui", EntryPoint = "igteMoveUp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteMoveUp(IntPtr ins, int aAmount, bool aSelect);

	[DllImport("cimgui", EntryPoint = "igteMoveDown", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteMoveDown(IntPtr ins, int aAmount, bool aSelect);

	[DllImport("cimgui", EntryPoint = "igteMoveLeft", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteMoveLeft(IntPtr ins, int aAmount, bool aSelect, bool aWordMode);

	[DllImport("cimgui", EntryPoint = "igteMoveRight", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteMoveRight(IntPtr ins, int aAmount, bool aSelect, bool aWordMode);

	[DllImport("cimgui", EntryPoint = "igteMoveTop", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteMoveTop(IntPtr ins, bool aSelect);

	[DllImport("cimgui", EntryPoint = "igteMoveBottom", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteMoveBottom(IntPtr ins, bool aSelect);

	[DllImport("cimgui", EntryPoint = "igteMoveHome", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteMoveHome(IntPtr ins, bool aSelect);

	[DllImport("cimgui", EntryPoint = "igteMoveEnd", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteMoveEnd(IntPtr ins, bool aSelect);

	[DllImport("cimgui", EntryPoint = "igteSetSelectionStart", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteSetSelectionStart(IntPtr ins, Coordinates aPosition);

	[DllImport("cimgui", EntryPoint = "igteSetSelectionEnd", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteSetSelectionEnd(IntPtr ins, Coordinates aPosition);

	[DllImport("cimgui", EntryPoint = "igteSetSelection", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteSetSelection(IntPtr ins, Coordinates aStart, Coordinates aEnd, SelectionMode aMode);

	[DllImport("cimgui", EntryPoint = "igteSelectWordUnderCursor", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteSelectWordUnderCursor(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteSelectAll", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteSelectAll(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteHasSelection", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool IgteHasSelection(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteCopy", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteCopy(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteCut", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteCut(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igtePaste", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgtePaste(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteDelete", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteDelete(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteCanUndo", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool IgteCanUndo(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteCanRedo", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool IgteCanRedo(IntPtr ins);

	[DllImport("cimgui", EntryPoint = "igteUndo", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteUndo(IntPtr ins, int aSteps);

	[DllImport("cimgui", EntryPoint = "igteRedo", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteRedo(IntPtr ins, int aSteps);

	[DllImport("cimgui", EntryPoint = "igteGetDarkPalette", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint* IgteGetDarkPalette();

	[DllImport("cimgui", EntryPoint = "igteGetLightPalette", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint* IgteGetLightPalette();

	[DllImport("cimgui", EntryPoint = "igteGetRetroBluePalette", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint* IgteGetRetroBluePalette();

	[DllImport("cimgui", EntryPoint = "igteDeleteArray", CallingConvention = CallingConvention.Cdecl)]
	public static extern void IgteDeleteArray(void* ptr);
}
