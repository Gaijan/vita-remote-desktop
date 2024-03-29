/*
Copyright (c) 2013, Erick<RetroZelda>Folckemer
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the <organization> nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Collections.Generic;
using System.Threading;
using Sce.PlayStation.Core.Graphics;

namespace VitaRemoteClient
{
	public static class Frame
	{
		private static Texture2D screenTexture;
		
		private static bool _frameReady = false;
		private static int _width = 0;
		private static int _height = 0;
		private static int tc = 0;
		
		private static bool bRelativeDragOne = false;
		public static bool RelativeDragOne
		{
			get { return bRelativeDragOne;}
			set { bRelativeDragOne = value;}
		}
		
		private static bool bRelativeDragTwo = false;
		public static bool RelativeDragTwo
		{
			get { return bRelativeDragTwo;}
			set { bRelativeDragTwo = value;}
		}
		
		
		public static int TC
		{
			get{ return tc;}
			set{ tc = value;}
		}
		
		public static int Width
		{
			get{return _width;}
			set{_width = value;
			}
		}
		
		public static int Height
		{
			get{return _height;}
			set{_height = value;
			}
		}
		
		
		public static bool FrameReady
		{
			get{return _frameReady;}
			set { _frameReady = value;}
		}
		
		public static Texture2D ScreenTexture
		{
			get { return screenTexture;}
			set { screenTexture = value;}
		}
		
		/*
		public static byte[] FrameBuffer1
		{
			get{
				return _FrameBuffer1;
			}
			set{
				_FrameBuffer1 = value;
			}
		}
		
		
		public static byte[] FrameBuffer2
		{
			get{
				_frameReady = false;
				return _FrameBuffer2;
			}
			set{
				_frameReady = true;
				_FrameBuffer2 = value;
			}
		}	
		*/
	}
}

