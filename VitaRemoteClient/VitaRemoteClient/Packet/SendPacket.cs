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
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;

/*
 * Out packet IDs
 * NOTE: 501 -> 507 send intX and intY
 *     : 
 * 501 - sendTap
 * 502 - sendDoubleTap
 * 503 - sendDrag1
 * 504 - sendDrag2
 * 505 - sendLongPress
 * 506 - sendDragStart
 * 507 - sendDragEnd
 * 401 - sendReady
 * 301 - sendGamePadInput
 * 302 - sendSensorData
 * */

namespace VitaRemoteClient
{
	public class SendPacket
	{
		private static TCPConnection socket;
		
		#region OLD_STUFF
		/*
		public static void sendLeftMouseClick(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 101; 
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		
		public static void sendLeftMouseDoubleClick(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 102; 
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		
		public static void sendDrag(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 103; 
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		
		public static void sendMouseMove(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 104; 
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		
		public static void sendRightMouseClick(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 105; 
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
			
		}
		
		public static void sendRightMouseDoubleClick(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 106; 
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
			
		}
		
		public static void sendLeftMouseDown(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 107; 
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
			
		}
		
		public static void sendLeftMouseUp(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 108; 
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
			
		}
		*/
		#endregion
		
		public static void Init(TCPConnection tcpSocket)
		{
			socket = tcpSocket;
		}
		
		
		#region TOUCH_PACKETS
		public static void sendTap(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 501;
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		public static void sendDoubleTap(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 502;
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		
		public static void sendDrag1(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 503;
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		public static void sendDrag2(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 504; 
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		
		public static void sendLongPress(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 505; 
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		
		public static void sendDragStart(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 506; 
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		public static void sendDragEnd(int x, int y)
		{
			Packet msg = new Packet();
			msg.ID = 507; 
			msg.Data = coordsToByte(x,y);
			socket.send(msg);
		}
		#endregion
		
		
		public static void sendGamePadInput(byte[] dataInput)
		{
			Packet msg = new Packet();
			msg.ID = 301;
			msg.Data = dataInput;
			socket.send(msg);
		}
		
		public static void sendReady()
		{
			Packet msg = new Packet();
			msg.ID = 401;
			msg.Data = new byte[]{255,255};
			socket.send(msg);
		}
		
		public static void sendSensorData(int avX, int avY, int avZ, int aX, int aY, int aZ)
		{
			byte[] data = new byte[12];
			
			Array.Copy(BitConverter.GetBytes(avX),0,data,0,2);
			Array.Copy(BitConverter.GetBytes(avY),0,data,2,2);
			Array.Copy(BitConverter.GetBytes(avZ),0,data,4,2);
			Array.Copy(BitConverter.GetBytes(aX),0,data,6,2);
			Array.Copy(BitConverter.GetBytes(aY),0,data,8,2);
			Array.Copy(BitConverter.GetBytes(aZ),0,data,10,2);
			
			Packet msg = new Packet();
			msg.ID = 302;
			msg.Data = data;
			socket.send(msg);
		}
		
		public static byte[] coordsToByte(int x, int y)
		{
			byte[] data = new byte[4];
			byte[] _x = BitConverter.GetBytes(x);
			byte[] _y = BitConverter.GetBytes(y);
			Array.Copy(_x ,0,data,0,2);
			Array.Copy(_y,0,data,2,2);
			return data;
		}
	}
}

