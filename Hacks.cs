using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brookshook_DMA
{
    static class Hack
    {
        private static uint FindDMAAddy32(uint baseAddy, List<uint> offsets)
        {
            uint pointer = baseAddy;
            foreach (var offset in offsets)
            {
                pointer = ReadValueU(pointer, 4);
                pointer += offset;
            }
            return pointer;
        }

        private static int ReadValue(uint pointer, uint bytesToRead)
        {
            byte[] readData = Data.VmmHandle.MemRead(Data.CsgoPid, pointer, bytesToRead);
            return BitConverter.ToInt32(readData);
        }
        private static uint ReadValueU(uint pointer, uint bytesToRead)
        {
            byte[] readData = Data.VmmHandle.MemRead(Data.CsgoPid, pointer, bytesToRead);
            return BitConverter.ToUInt32(readData);
        }
        private static float ReadFloat(uint pointer, uint bytesToRead)
        {
            byte[] readData = Data.VmmHandle.MemRead(Data.CsgoPid, pointer, bytesToRead);
            return BitConverter.ToSingle(readData);
        }

        public static bool IsOwnTeam(int localEntityIndex, int otherEntityIndex)
        {
            uint ownTeamPtr = FindDMAAddy32(Data.ClientDll + (uint)(signatures.dwEntityList + (0x10 * localEntityIndex)), new List<uint> { 0x00, netvars.m_iTeamNum });
            uint otherTeamPtr = FindDMAAddy32(Data.ClientDll + (uint)(signatures.dwEntityList + (0x10 * otherEntityIndex)), new List<uint> { 0x00, netvars.m_iTeamNum });

            return ReadValue(ownTeamPtr, 4) == ReadValue(otherTeamPtr, 4);
        }

        public static int GetEntityHealth(int index)
        {
            uint healthPtr = FindDMAAddy32(Data.ClientDll + (uint)(signatures.dwEntityList + (0x10 * index)), new List<uint> { netvars.m_iHealth });
            return ReadValue(healthPtr, 4);
        }

        public static bool IsEntityDormant(int index)
        {
            uint isDormantPtr = FindDMAAddy32(Data.ClientDll + (uint)(signatures.dwEntityList + (0x10 * index)), new List<uint> { signatures.m_bDormant });
            return ReadValue(isDormantPtr, 1) == 0;
        }

        public static Vector3 GetBonePosition(int index, int bone)
        {
            uint bonePtr = FindDMAAddy32(Data.ClientDll + (uint)(signatures.dwEntityList + (0x10 * index)), new List<uint> { netvars.m_dwBoneMatrix });

            Vector3 bones = new Vector3(
                ReadFloat(bonePtr + 0x30 * (uint)bone + 0x0C, 4),
                ReadFloat(bonePtr + 0x30 * (uint)bone + 0x1C, 4),
                ReadFloat(bonePtr + 0x30 * (uint)bone + 0x2C, 4)
            );

            return bones;
        }

        public static Vector3 GetCrosshairPosition(int index)
        {
            uint vecOriginPtr = FindDMAAddy32(Data.ClientDll + (uint)(signatures.dwEntityList + (0x10 * index)), new List<uint> { netvars.m_vecOrigin });
            uint vecViewOfsPtr = FindDMAAddy32(Data.ClientDll + (uint)(signatures.dwEntityList + (0x10 * index)), new List<uint> { netvars.m_vecViewOffset });

            Vector3 vecOrigin = new Vector3(
                ReadFloat(vecOriginPtr, 4),
                ReadFloat(vecOriginPtr + 4, 4),
                ReadFloat(vecOriginPtr + 8, 4)
            );

            Vector3 vecViewOffset = new Vector3(
                ReadFloat(vecViewOfsPtr, 4),
                ReadFloat(vecViewOfsPtr + 4, 4),
                ReadFloat(vecViewOfsPtr + 8, 4)
            );

            Vector3 crosshairPos = new Vector3(
                vecOrigin.X + vecViewOffset.X,
                vecOrigin.Y + vecViewOffset.Y,
                vecOrigin.Z + vecViewOffset.Z
            );
            return crosshairPos;
        }
        public static Vector3 GetViewAngle()
        {
            uint viewAnglePtr = Data.EngineDll + (uint)(signatures.dwViewMatrix) + signatures.dwClientState_ViewAngles;

            Vector3 viewAngles = new Vector3(
                ReadFloat(viewAnglePtr, 4),
                ReadFloat(viewAnglePtr + 4, 4),
                ReadFloat(viewAnglePtr + 8, 4)
            );

            return viewAngles;
        }

        public static bool IsEntityValid(int index)
        {
            if (IsEntityDormant(index) && GetEntityHealth(index) > 0 && index != 0)
                return true;
            return false;
        }
        public static bool IsIngame()
        {
            uint localPlayer = FindDMAAddy32(Data.ClientDll + (signatures.dwEntityList), new List<uint> {});
            return ReadValue(localPlayer, 4) != 0;
        }

        public static Vector2? WorldToScreen(Vector3 position, Vector2 windowRect)
        {

            uint viewMatrixPtr = FindDMAAddy32(Data.ClientDll + (signatures.dwViewMatrix), new List<uint> { });
            float[] viewMatrix = new float[] {
                ReadFloat(viewMatrixPtr, 4),
                ReadFloat(viewMatrixPtr + 4, 4),
                ReadFloat(viewMatrixPtr + 8, 4),
                ReadFloat(viewMatrixPtr + 12, 4),
                ReadFloat(viewMatrixPtr + 16, 4),
                ReadFloat(viewMatrixPtr + 20, 4),
                ReadFloat(viewMatrixPtr + 24, 4),
                ReadFloat(viewMatrixPtr + 28, 4),
                ReadFloat(viewMatrixPtr + 32, 4),
                ReadFloat(viewMatrixPtr + 36, 4),
                ReadFloat(viewMatrixPtr + 40, 4),
                ReadFloat(viewMatrixPtr + 44, 4),
                ReadFloat(viewMatrixPtr + 48, 4),
                ReadFloat(viewMatrixPtr + 52, 4),
                ReadFloat(viewMatrixPtr + 56, 4),
                ReadFloat(viewMatrixPtr + 60, 4)
            };

            Vector4 clipCoords = new (
                position.X * viewMatrix[0] +
                position.Y * viewMatrix[1] +
                position.Z * viewMatrix[2] +
                viewMatrix[3],

                position.X * viewMatrix[4] +
                position.Y * viewMatrix[5] +
                position.Z * viewMatrix[6] +
                viewMatrix[7],

                position.X * viewMatrix[8] +
                position.Y * viewMatrix[9] + 
                position.Z * viewMatrix[10] +
                viewMatrix[11],

                position.X * viewMatrix[12] +
                position.Y * viewMatrix[13] +
                position.Y * viewMatrix[14] +
                viewMatrix[15]
            );

            if (clipCoords.W < 0.1)
                return null;

            Vector2 ndc = new Vector2(
                clipCoords.X / clipCoords.W,
                clipCoords.Y / clipCoords.W
            );

            return new Vector2(
                (windowRect.X / 2 * ndc.X) + (ndc.X + windowRect.X / 2),
                (windowRect.Y / 2 * ndc.Y) + (ndc.Y + windowRect.Y / 2)
            );
        }
    }


    internal class Radar
    {
        public Radar()
        {

        }
    }

    internal class Aimbot
    {
        public Aimbot()
        {

        }


    }
}
