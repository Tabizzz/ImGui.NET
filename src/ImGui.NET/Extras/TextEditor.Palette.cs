namespace ImGuiNET.Extras;

public partial class TextEditor
{
	public class ColorPalette
	{
		public readonly uint[] source = new uint[(int)PaletteIndex.Max];

		public ColorPalette(uint[] source)
		{
			this.source = source;
		}

		public ColorPalette()
		{

		}

		public uint this[PaletteIndex index]
		{
			get
			{
				return source[(int)index]; 
			}
			set
			{
				source[(int)index] = value;
			}
		}

		public uint this[int index]
		{
			get
			{
				return source[index];
			}
			set
			{
				source[index] = value;
			}
		}
	}
}
