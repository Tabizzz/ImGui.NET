namespace ImGuiNET.Extras;

public partial class TextEditor
{
	public enum PaletteIndex
	{
		Default = 0,
		Keyword = 1,
		Number = 2,
		String = 3,
		CharLiteral = 4,
		Punctuation = 5,
		Preprocessor = 6,
		Identifier = 7,
		KnownIdentifier = 8,
		PreprocIdentifier = 9,
		Comment = 10,
		MultiLineComment = 11,
		Background = 12,
		Cursor = 13,
		Selection = 14,
		ErrorMarker = 15,
		Breakpoint = 16,
		LineNumber = 17,
		CurrentLineFill = 18,
		CurrentLineFillInactive = 19,
		CurrentLineEdge = 20,
		Max = 21
	}

	public enum SelectionMode
	{
		Normal = 0,
		Word = 1,
		Line = 2
	}
}
