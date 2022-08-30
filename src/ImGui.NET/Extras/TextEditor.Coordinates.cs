using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ImGuiNET.Extras;

public partial class TextEditor
{
	[StructLayout(LayoutKind.Sequential, Size = 8)]
	public struct Coordinates
	{
		public int mLine;
		public int mColumn;
	}

	public unsafe struct CoordinatesPtr
	{
		public Coordinates* NativePtr { get; }
		public CoordinatesPtr(Coordinates* nativePtr) => NativePtr = nativePtr;
		public CoordinatesPtr(IntPtr nativePtr) => NativePtr = (Coordinates*)nativePtr;
		public static implicit operator CoordinatesPtr(Coordinates* nativePtr) => new CoordinatesPtr(nativePtr);
		public static implicit operator Coordinates*(CoordinatesPtr wrappedPtr) => wrappedPtr.NativePtr;
		public static implicit operator CoordinatesPtr(IntPtr nativePtr) => new CoordinatesPtr(nativePtr);

		public void Destroy()
		{
			igteNative.CoordinatesDestroy(NativePtr);
		}
	}
}
