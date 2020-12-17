#region сборка LeptonUVC, Version=1.0.6809.28377, Culture=neutral, PublicKeyToken=null
// C:\Users\Andrei\Desktop\C#\Lepton\Lepton\lib_x86\LeptonUVC.dll
#endregion

using Lepton.Unit;
using System;
using System.Collections.Generic;

namespace Lepton
{
    //
    // Сводка:
    //     The CCI handles getting and setting values on the lepton as well as running commands.
    //     The commands that can be run on the lepton are grouped into collections. There
    //     are radiometric commands (Lepton.CCI.Rad), gain control commands (Lepton.CCI.Agc),
    //     system commands (Lepton.CCI.Sys), advanced commands (Lepton.CCI.Oem), and video
    //     commands (Lepton.CCI.Vid). CCI instances have instances of these classes in their
    //     Lepton.CCI.rad, Lepton.CCI.agc, Lepton.CCI.sys, Lepton.CCI.oem, and Lepton.CCI.vid
    //     fields.
    public class CCI
    {
        //
        // Сводка:
        //     The version of the SDK currently in use
        public static string SDKVersion;
        public UVC port;
        public Agc agc;
        public Oem oem;
        public Rad rad;
        public Sys sys;
        public Vid vid;

        //
        // Сводка:
        //     Construct a CCI which connects the the Lepton over the given port.
        public CCI(UVC port);

        public static List<Handle> GetDevices();

        public class LepErrorClosingComm : LepCommError
        {
            public LepErrorClosingComm();
        }
        public class LepErrorStartingComm : LepCommError
        {
            public LepErrorStartingComm();
        }
        public class LepErrorCreatingComm : LepCommError
        {
            public LepErrorCreatingComm();
        }
        public class LepCommRangeError : LepCommError
        {
            public LepCommRangeError();
        }
        public class LepDivZeroError : LepProcessingError
        {
            public LepDivZeroError();
        }
        public class LepCommPortNotOpen : LepCommError
        {
            public LepCommPortNotOpen();
        }
        public class LepCommError : LepError
        {
            public LepCommError();
        }
        public class LepCommChecksumError : LepCommError
        {
            public LepCommChecksumError();
        }
        public class LepCommInvalidPortError : LepCommError
        {
            public LepCommInvalidPortError();
        }
        public class LepCommNoDev : LepCommError
        {
            public LepCommNoDev();
        }
        public class UnknownError : Error
        {
            public UnknownError();
        }
        public class LepCommErrorWritingComm : LepCommError
        {
            public LepCommErrorWritingComm();
        }
        public class LepCommErrorReadingComm : LepCommError
        {
            public LepCommErrorReadingComm();
        }
        public class LepCommCountError : LepCommError
        {
            public LepCommCountError();
        }
        public class LepProcessingError : LepError
        {
            public LepProcessingError();
        }
        public class Handle
        {
            public Handle(string name, string monikerPath);

            public string MonikerPath { get; }
            public string Name { get; }

            public CCI Open();
        }
        //
        // Сводка:
        //     Attempted to communicate with a disconnected device
        public class DisconnectedError : Exception
        {
            public DisconnectedError();
        }
        //
        // Сводка:
        //     Base class for errors originating from the device itself
        public class LeptonError : Exception
        {
            public LeptonError();
        }
        //
        // Сводка:
        //     This module provides command and control of the video output Automatic Gain Control
        //     (AGC) operation. The cameraâ€™s video data may be processed to provide an optimum
        //     scene contrast using one of two policies: HEQ-Histogram Equalization, or by Linear
        //     Histogram stretching. This module provides commands to enable, select, and control
        //     the AGC processing.
        public class Agc
        {
            public Agc(UVC port);

            //
            // Сводка:
            //     AGC Calculation Enable State
            //     This parameter controls the camera AGC calculations operations. If enabled, the
            //     current video histogram and AGC policy will be calculated for each input frame.
            //     If disabled, then no AGC calculations are performed and the current state of
            //     the ITT is preserved. For smooth AGC on /off operation, it is recommended to
            //     have this enabled.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_DISABLE – LEP_AGC_ENABLE – LEP_AGC_DISABLE – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x48
            //     With Set 0x49
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcCalcEnableState() – Updates agcCalculationEnableStatePtr
            //     with the Camera’s current AGC Calculation enable state –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcCalcEnableState() – Sets Camera’s current
            //     AGC Calculation enable state to agcCalculationEnableState –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcCalcEnableState( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_ENABLE_E_PTR agcCalculationEnableStatePtr ) LEP_RESULT LEP_SetAgcCalcEnableState(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ENABLE_E agcCalculationEnableState
            //     ) /* AGC Enable Enum */ typedef enum LEP_AGC_ENABLE_TAG { LEP_AGC_DISABLE=0,
            //     LEP_AGC_ENABLE, LEP_END_AGC_ENABLE }LEP_AGC_ENABLE_E, *LEP_AGC_ENABLE_E_PTR;
            public Enable GetCalcEnableState();
            //
            // Сводка:
            //     AGC Calculation Enable State
            //     This parameter controls the camera AGC calculations operations. If enabled, the
            //     current video histogram and AGC policy will be calculated for each input frame.
            //     If disabled, then no AGC calculations are performed and the current state of
            //     the ITT is preserved. For smooth AGC on /off operation, it is recommended to
            //     have this enabled.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_DISABLE – LEP_AGC_ENABLE – LEP_AGC_DISABLE – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x48
            //     With Set 0x49
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcCalcEnableState() – Updates agcCalculationEnableStatePtr
            //     with the Camera’s current AGC Calculation enable state –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcCalcEnableState() – Sets Camera’s current
            //     AGC Calculation enable state to agcCalculationEnableState –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcCalcEnableState( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_ENABLE_E_PTR agcCalculationEnableStatePtr ) LEP_RESULT LEP_SetAgcCalcEnableState(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ENABLE_E agcCalculationEnableState
            //     ) /* AGC Enable Enum */ typedef enum LEP_AGC_ENABLE_TAG { LEP_AGC_DISABLE=0,
            //     LEP_AGC_ENABLE, LEP_END_AGC_ENABLE }LEP_AGC_ENABLE_E, *LEP_AGC_ENABLE_E_PTR;
            public Enable GetCalcEnableStateChecked();
            //
            // Сводка:
            //     AGC Enable and Disable
            //     To turn AGC ON is to enable AGC processing. Disabling the AGC will turn the AGC
            //     processing OFF and the video data will not be optimized for scene contrast. This
            //     command sets and retrieves the AGC state.
            //     Note that the Focus metric (see 4.5.3) must be disabled when AGC is enabled.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_DISABLE – LEP_AGC_ENABLE – LEP_AGC_DISABLE – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base 0x00
            //     With Get 0x00
            //     With Set 0x01
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcEnableState() – Updates agcEnableStatePtr
            //     with the Camera’s current AGC enable state. –
            //     All Lepton Configurations – LEP_SetAgcEnableState() – Sets Camera’s current AGC
            //     enable state to agcEnableState –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ENABLE_E_PTR
            //     agcEnableStatePtr) LEP_RESULT LEP_SetAgcEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_AGC_ENABLE_E agcEnableState) /* AGC Enable Enum */ typedef enum
            //     LEP_AGC_ENABLE_TAG { LEP_AGC_DISABLE=0, LEP_AGC_ENABLE, LEP_END_AGC_ENABLE }LEP_AGC_ENABLE_E,
            //     *LEP_AGC_ENABLE_E_PTR;
            public Enable GetEnableState();
            //
            // Сводка:
            //     AGC Enable and Disable
            //     To turn AGC ON is to enable AGC processing. Disabling the AGC will turn the AGC
            //     processing OFF and the video data will not be optimized for scene contrast. This
            //     command sets and retrieves the AGC state.
            //     Note that the Focus metric (see 4.5.3) must be disabled when AGC is enabled.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_DISABLE – LEP_AGC_ENABLE – LEP_AGC_DISABLE – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base 0x00
            //     With Get 0x00
            //     With Set 0x01
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcEnableState() – Updates agcEnableStatePtr
            //     with the Camera’s current AGC enable state. –
            //     All Lepton Configurations – LEP_SetAgcEnableState() – Sets Camera’s current AGC
            //     enable state to agcEnableState –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ENABLE_E_PTR
            //     agcEnableStatePtr) LEP_RESULT LEP_SetAgcEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_AGC_ENABLE_E agcEnableState) /* AGC Enable Enum */ typedef enum
            //     LEP_AGC_ENABLE_TAG { LEP_AGC_DISABLE=0, LEP_AGC_ENABLE, LEP_END_AGC_ENABLE }LEP_AGC_ENABLE_E,
            //     *LEP_AGC_ENABLE_E_PTR;
            public Enable GetEnableStateChecked();
            public ushort GetHeqBinExtension();
            public ushort GetHeqBinExtensionChecked();
            //
            // Сводка:
            //     AGC HEQ Clip Limit High
            //     This parameter defines the maximum number of pixels allowed to accumulate in
            //     any given histogram bin. Any additional pixels in a given bin are clipped. The
            //     effect of this parameter is to limit the influence of highly-populated bins on
            //     the resulting HEQ transformation function.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 4,800 – 4,800 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 19,200 – 19,200 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x2C
            //     With Set 0x2D
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcHeqClipLimitHigh() – Updates agcHeqClipLimitHighPtr
            //     with the Camera’s current HEQ level high value –
            //     All Lepton Configurations – LEP_SetAgcHeqClipLimitHigh() – Sets Camera’s current
            //     HEQ level high value to agcHeqClipLimitHigh –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqClipLimitHigh(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqClipLimitHighPtr) LEP_RESULT LEP_SetAgcHeqClipLimitHigh(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 agcHeqClipLimitHigh)
            public ushort GetHeqClipLimitHigh();
            //
            // Сводка:
            //     AGC HEQ Clip Limit High
            //     This parameter defines the maximum number of pixels allowed to accumulate in
            //     any given histogram bin. Any additional pixels in a given bin are clipped. The
            //     effect of this parameter is to limit the influence of highly-populated bins on
            //     the resulting HEQ transformation function.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 4,800 – 4,800 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 19,200 – 19,200 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x2C
            //     With Set 0x2D
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcHeqClipLimitHigh() – Updates agcHeqClipLimitHighPtr
            //     with the Camera’s current HEQ level high value –
            //     All Lepton Configurations – LEP_SetAgcHeqClipLimitHigh() – Sets Camera’s current
            //     HEQ level high value to agcHeqClipLimitHigh –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqClipLimitHigh(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqClipLimitHighPtr) LEP_RESULT LEP_SetAgcHeqClipLimitHigh(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 agcHeqClipLimitHigh)
            public ushort GetHeqClipLimitHighChecked();
            //
            // Сводка:
            //     AGC HEQ Clip Limit Low
            //     This parameter defines an artificial population that is added to every non-empty
            //     histogram bin. In other words, if the Clip Limit Low is set to L, a bin with
            //     an actual population of X will have an effective population of L + X. y empty
            //     bin that is nearby a populated bin will be given an artificial population of
            //     L. The effect of higher values is to provide a more linear transfer function;
            //     lower values provide a more non-linear (equalized) transfer function. This command
            //     is deprecated for Lepton 3 (replaced by Linear Percent).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 1024 – 512 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x30
            //     With Set 0x31
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcHeqClipLimitLow() – Updates agcHeqClipLimitLowPtr
            //     with the Camera’s current HEQ level Low value –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcHeqClipLimitLow() – Sets Camera’s current
            //     HEQ level Low value to agcHeqClipLimitLow –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqClipLimitLow(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqClipLimitLowPtr) LEP_RESULT LEP_SetAgcHeqClipLimitLow(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 agcHeqClipLimitLow)
            public ushort GetHeqClipLimitLow();
            //
            // Сводка:
            //     AGC HEQ Clip Limit Low
            //     This parameter defines an artificial population that is added to every non-empty
            //     histogram bin. In other words, if the Clip Limit Low is set to L, a bin with
            //     an actual population of X will have an effective population of L + X. y empty
            //     bin that is nearby a populated bin will be given an artificial population of
            //     L. The effect of higher values is to provide a more linear transfer function;
            //     lower values provide a more non-linear (equalized) transfer function. This command
            //     is deprecated for Lepton 3 (replaced by Linear Percent).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 1024 – 512 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x30
            //     With Set 0x31
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcHeqClipLimitLow() – Updates agcHeqClipLimitLowPtr
            //     with the Camera’s current HEQ level Low value –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcHeqClipLimitLow() – Sets Camera’s current
            //     HEQ level Low value to agcHeqClipLimitLow –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqClipLimitLow(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqClipLimitLowPtr) LEP_RESULT LEP_SetAgcHeqClipLimitLow(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 agcHeqClipLimitLow)
            public ushort GetHeqClipLimitLowChecked();
            //
            // Сводка:
            //     AGC HEQ Dampening Factor
            //     This parameter is the amount of temporal dampening applied to the HEQ transformation
            //     function. An IIR filter of the form (N/256) * previous + ((256-N)/256) * current
            //     is applied , and the HEQ dampening factor represents the value N in the equation,
            //     i.e., a value that applies to the amount of influence the previous HEQ transformation
            //     function has on the current function. . The lower the value of N the higher the
            //     influence of the current video frame whereas the higher the value of N the more
            //     influence the previous damped transfer function has.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 256 – 64 – N/A – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcHeqDampingFactor() – Updates agcHeqDampingFactorPtr
            //     with the Camera’s current HEQ dampening factor –
            //     All Lepton Configurations – LEP_SetAgcHeqDampingFactor() – Sets Camera’s current
            //     HEQ dampening factor to agcHeqDampingFactor –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqDampingFactor(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqDampingFactorPtr) LEP_RESULT LEP_SetAgcHeqDampingFactor(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 gcHeqDampingFactor)
            public ushort GetHeqDampingFactor();
            //
            // Сводка:
            //     AGC HEQ Dampening Factor
            //     This parameter is the amount of temporal dampening applied to the HEQ transformation
            //     function. An IIR filter of the form (N/256) * previous + ((256-N)/256) * current
            //     is applied , and the HEQ dampening factor represents the value N in the equation,
            //     i.e., a value that applies to the amount of influence the previous HEQ transformation
            //     function has on the current function. . The lower the value of N the higher the
            //     influence of the current video frame whereas the higher the value of N the more
            //     influence the previous damped transfer function has.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 256 – 64 – N/A – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcHeqDampingFactor() – Updates agcHeqDampingFactorPtr
            //     with the Camera’s current HEQ dampening factor –
            //     All Lepton Configurations – LEP_SetAgcHeqDampingFactor() – Sets Camera’s current
            //     HEQ dampening factor to agcHeqDampingFactor –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqDampingFactor(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqDampingFactorPtr) LEP_RESULT LEP_SetAgcHeqDampingFactor(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 gcHeqDampingFactor)
            public ushort GetHeqDampingFactorChecked();
            //
            // Сводка:
            //     AGC HEQ Empty Counts
            //     This parameter specifies the maximum number of pixels in a bin that will be interpreted
            //     as an empty bin. Histogram bins with this number of pixels or less will be processed
            //     as an empty bin.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 2^14 -1 – 2 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x3C
            //     With Set 0x3D
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcHeqEmptyCount() – Updates emptyCountPtr
            //     with the Camera’s current HEQ transfer function’s bin empty count –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcHeqEmptyCount() – Sets Camera’s current
            //     HEQ transfer function’s bin empty count to emptyCount –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqEmptyCount(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_HEQ_EMPTY_COUNT_T_PTR
            //     emptyCountPtr) LEP_RESULT LEP_SetAgcHeqEmptyCount(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_AGC_HEQ_EMPTY_COUNT_T emptyCount)
            public ushort GetHeqEmptyCount();
            //
            // Сводка:
            //     AGC HEQ Empty Counts
            //     This parameter specifies the maximum number of pixels in a bin that will be interpreted
            //     as an empty bin. Histogram bins with this number of pixels or less will be processed
            //     as an empty bin.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 2^14 -1 – 2 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x3C
            //     With Set 0x3D
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcHeqEmptyCount() – Updates emptyCountPtr
            //     with the Camera’s current HEQ transfer function’s bin empty count –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcHeqEmptyCount() – Sets Camera’s current
            //     HEQ transfer function’s bin empty count to emptyCount –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqEmptyCount(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_HEQ_EMPTY_COUNT_T_PTR
            //     emptyCountPtr) LEP_RESULT LEP_SetAgcHeqEmptyCount(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_AGC_HEQ_EMPTY_COUNT_T emptyCount)
            public ushort GetHeqEmptyCountChecked();
            //
            // Сводка:
            //     AGC HEQ Linear Percent
            //     This parameter controls the camera AGC HEQ algorithm’s linear percent. The linear
            //     percent parameter fills holes in the histogram with pixels to avoid undesirable
            //     compression in 8-bit irradiance levels. Similar to the low clip limit, pixels
            //     are added to each full bin and to an additional number of empty bins following
            //     full bins. The linear percent parameter is more automatic than allowing the user
            //     to specify the low clip limit; the linear percent adjusts low clip limit based
            //     on the scene content and the desired percentage of total pixels in the histogram.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 100 – 20 – percent – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x4C
            //     With Set 0x4D
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 3.0 – LEP_GetAgcHeqLinearPercent() – Updates agcHeqLinearPercentPtr with
            //     the Camera’s current AGC HEQ Linear Percent value –
            //     Lepton 3.0 – LEP_SetAgcHeqLinearPercent() – Sets Camera’s current AGC HEQ Linear
            //     Percent to agcHeqLinearPercent –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqLinearPercent( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqLinearPercentPtr) LEP_RESULT LEP_SetAgcHeqLinearPercent( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 agcHeqLinearPercent)
            public ushort GetHeqLinearPercent();
            //
            // Сводка:
            //     AGC HEQ Linear Percent
            //     This parameter controls the camera AGC HEQ algorithm’s linear percent. The linear
            //     percent parameter fills holes in the histogram with pixels to avoid undesirable
            //     compression in 8-bit irradiance levels. Similar to the low clip limit, pixels
            //     are added to each full bin and to an additional number of empty bins following
            //     full bins. The linear percent parameter is more automatic than allowing the user
            //     to specify the low clip limit; the linear percent adjusts low clip limit based
            //     on the scene content and the desired percentage of total pixels in the histogram.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 100 – 20 – percent – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x4C
            //     With Set 0x4D
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 3.0 – LEP_GetAgcHeqLinearPercent() – Updates agcHeqLinearPercentPtr with
            //     the Camera’s current AGC HEQ Linear Percent value –
            //     Lepton 3.0 – LEP_SetAgcHeqLinearPercent() – Sets Camera’s current AGC HEQ Linear
            //     Percent to agcHeqLinearPercent –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqLinearPercent( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqLinearPercentPtr) LEP_RESULT LEP_SetAgcHeqLinearPercent( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 agcHeqLinearPercent)
            public ushort GetHeqLinearPercentChecked();
            public ushort GetHeqMaxGain();
            public ushort GetHeqMaxGainChecked();
            public ushort GetHeqMidPoint();
            public ushort GetHeqMidPointChecked();
            public ushort GetHeqNormalizationFactor();
            public ushort GetHeqNormalizationFactorChecked();
            //
            // Сводка:
            //     AGC HEQ Output Scale Factor
            //     This parameter specifies the output format for HEQ as either 8-bits (values range
            //     0 to 255), or 14-bit (values range from 0 to 16383).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_SCALE_TO_8_BITS – LEP_AGC_SCALE_TO_14_BITS – LEP_AGC_SCALE_TO_8_BITS
            //     – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x44
            //     With Set 0x45
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcHeqScaleFactor() – Updates scaleFactorPtr
            //     with the Camera’s current AGC HEQ Output Scale Factor –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcHeqScaleFactor() – Sets Camera’s current
            //     AGC HEQ Output Scale Factor to scaleFactor –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqScaleFactor (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_HEQ_SCALE_FACTOR_E_PTR scaleFactorPtr) LEP_RESULT LEP_SetAgcHeqScaleFactor
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_HEQ_SCALE_FACTOR_E scaleFactor)
            //     /* AGC Output Scale Factor Structure */ typedef enum LEP_AGC_SCALE_FACTOR_E_TAG
            //     { LEP_AGC_SCALE_TO_8_BITS = 0, LEP_AGC_SCALE_TO_14_BITS, LEP_AGC_END_SCALE_TO
            //     }LEP_AGC_HEQ_SCALE_FACTOR_E, *LEP_AGC_HEQ_SCALE_FACTOR_E_PTR;
            public HeqScaleFactor GetHeqScaleFactor();
            //
            // Сводка:
            //     AGC HEQ Output Scale Factor
            //     This parameter specifies the output format for HEQ as either 8-bits (values range
            //     0 to 255), or 14-bit (values range from 0 to 16383).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_SCALE_TO_8_BITS – LEP_AGC_SCALE_TO_14_BITS – LEP_AGC_SCALE_TO_8_BITS
            //     – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x44
            //     With Set 0x45
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcHeqScaleFactor() – Updates scaleFactorPtr
            //     with the Camera’s current AGC HEQ Output Scale Factor –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcHeqScaleFactor() – Sets Camera’s current
            //     AGC HEQ Output Scale Factor to scaleFactor –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqScaleFactor (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_HEQ_SCALE_FACTOR_E_PTR scaleFactorPtr) LEP_RESULT LEP_SetAgcHeqScaleFactor
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_HEQ_SCALE_FACTOR_E scaleFactor)
            //     /* AGC Output Scale Factor Structure */ typedef enum LEP_AGC_SCALE_FACTOR_E_TAG
            //     { LEP_AGC_SCALE_TO_8_BITS = 0, LEP_AGC_SCALE_TO_14_BITS, LEP_AGC_END_SCALE_TO
            //     }LEP_AGC_HEQ_SCALE_FACTOR_E, *LEP_AGC_HEQ_SCALE_FACTOR_E_PTR;
            public HeqScaleFactor GetHeqScaleFactorChecked();
            //
            // Сводка:
            //     AGC Histogram Statistics
            //     The AGC algorithms use the image histogram as input. This attribute returns the
            //     current Histogram statistics of minimum intensity, maximum intensity, mean intensity,
            //     and the number of pixels processed within the defined AGC ROI. This command is
            //     Read-only.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Units – Scale factor –
            //     minimum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     maximum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     mean intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     number of pixels
            //     – 0 – 4,800 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Units – Scale factor –
            //     minimum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     maximum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     mean intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     number of pixels
            //     – 0 – 19,200 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x0C
            //     SDK Data Length: Get 4 size of LEP_AGC_HISTOGRAM_STATISTICS_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcHistogramStatistics() – Updates agcHistogramStatisticsPtr
            //     with the Camera’s current AGC Histogram statistics –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHistogramStatistics(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_HISTOGRAM_STATISTICS_T_PTR *agcHistogramStatisticsPtr) /* AGC Histogram
            //     Statistics Structure */ typedef struct LEP_AGC_HISTOGRAM_STATISTICS_TAG { LEP_UINT16
            //     minIntensity; LEP_UINT16 maxIntensity; LEP_UINT16 meanIntensity; LEP_UINT16 numPixels;
            //     }LEP_AGC_HISTOGRAM_STATISTICS_T, *LEP_AGC_HISTOGRAM_STATISTICS_T_PTR;
            public HistogramStatistics GetHistogramStatistics();
            //
            // Сводка:
            //     AGC Histogram Statistics
            //     The AGC algorithms use the image histogram as input. This attribute returns the
            //     current Histogram statistics of minimum intensity, maximum intensity, mean intensity,
            //     and the number of pixels processed within the defined AGC ROI. This command is
            //     Read-only.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Units – Scale factor –
            //     minimum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     maximum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     mean intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     number of pixels
            //     – 0 – 4,800 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Units – Scale factor –
            //     minimum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     maximum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     mean intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     number of pixels
            //     – 0 – 19,200 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x0C
            //     SDK Data Length: Get 4 size of LEP_AGC_HISTOGRAM_STATISTICS_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcHistogramStatistics() – Updates agcHistogramStatisticsPtr
            //     with the Camera’s current AGC Histogram statistics –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHistogramStatistics(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_HISTOGRAM_STATISTICS_T_PTR *agcHistogramStatisticsPtr) /* AGC Histogram
            //     Statistics Structure */ typedef struct LEP_AGC_HISTOGRAM_STATISTICS_TAG { LEP_UINT16
            //     minIntensity; LEP_UINT16 maxIntensity; LEP_UINT16 meanIntensity; LEP_UINT16 numPixels;
            //     }LEP_AGC_HISTOGRAM_STATISTICS_T, *LEP_AGC_HISTOGRAM_STATISTICS_T_PTR;
            public HistogramStatistics GetHistogramStatisticsChecked();
            public ushort GetLinearDampeningFactor();
            public ushort GetLinearDampeningFactorChecked();
            public ushort GetLinearHistogramClipPercent();
            public ushort GetLinearHistogramClipPercentChecked();
            public ushort GetLinearHistogramTailSize();
            public ushort GetLinearHistogramTailSizeChecked();
            public ushort GetLinearMaxGain();
            public ushort GetLinearMaxGainChecked();
            public ushort GetLinearMidPoint();
            public ushort GetLinearMidPointChecked();
            //
            // Сводка:
            //     AGC Policy Select
            //     The camera supports 2 AGC policies to process incoming video data, histogram
            //     equalization (HEQ) and linear histogram stretch. This command sets and retrieves
            //     the AGC policy.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_LINEAR – LEP_AGC_HEQ – LEP_AGC_HEQ – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x04
            //     With Set 0x05
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcPolicy() – Updates agcPolicyPtr with the
            //     Camera’s current AGC policy. –
            //     All Lepton Configurations – LEP_SetAgcPolicy() – Sets Camera’s current AGC policy
            //     to agcPolicy. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcPolicy(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_POLICY_E_PTR
            //     agcPolicyPtr) LEP_RESULT LEP_SetAgcPolicy(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_POLICY_E agcPolicy) /* AGC Policy Enum */ typedef enum LEP_AGC_POLICY_TAG
            //     { LEP_AGC_LINEAR=0, LEP_AGC_HEQ, LEP_END_AGC_POLICY }LEP_AGC_POLICY_E, *LEP_AGC_POLICY_E_PTR;
            public Policy GetPolicy();
            //
            // Сводка:
            //     AGC Policy Select
            //     The camera supports 2 AGC policies to process incoming video data, histogram
            //     equalization (HEQ) and linear histogram stretch. This command sets and retrieves
            //     the AGC policy.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_LINEAR – LEP_AGC_HEQ – LEP_AGC_HEQ – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x04
            //     With Set 0x05
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcPolicy() – Updates agcPolicyPtr with the
            //     Camera’s current AGC policy. –
            //     All Lepton Configurations – LEP_SetAgcPolicy() – Sets Camera’s current AGC policy
            //     to agcPolicy. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcPolicy(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_POLICY_E_PTR
            //     agcPolicyPtr) LEP_RESULT LEP_SetAgcPolicy(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_POLICY_E agcPolicy) /* AGC Policy Enum */ typedef enum LEP_AGC_POLICY_TAG
            //     { LEP_AGC_LINEAR=0, LEP_AGC_HEQ, LEP_END_AGC_POLICY }LEP_AGC_POLICY_E, *LEP_AGC_POLICY_E_PTR;
            public Policy GetPolicyChecked();
            //
            // Сводка:
            //     AGC ROI Select
            //     The AGC algorithms utilize a histogram, which is collected from within a specified
            //     rectangular window or Region of Interest (ROI). This region is defined by 4 parameters:
            //     start column, start row, end column, and end row. The region is adjustable from
            //     full window to a sub-window.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Value – Units – Scale factor –
            //     start column
            //     – 0 – < = endCol – 0 – pixels – 1 –
            //     start row
            //     – 0 – < endRow – 0 – pixels – 1 –
            //     end column
            //     – >= startCol – 79 – 79 – pixels – 1 –
            //     end row
            //     – >= startRow – 59 – 59 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Value – Units – Scale factor –
            //     start column
            //     – 0 – < = endCol – 0 – pixels – 1 –
            //     start row
            //     – 0 – < endRow – 0 – pixels – 1 –
            //     end column
            //     – >= startCol – 159 – 159 – pixels – 1 –
            //     end row
            //     – >= startRow – 119 – 119 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x08
            //     With Set 0x09
            //     SDK Data Length: Get 4 size of LEP_AGC_ROI_T data type
            //     Set 4 size of LEP_AGC_ROI_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcROI() – Updates agcROIPtr with the Camera’s
            //     current AGC ROI –
            //     All Lepton Configurations – LEP_SetAgcROI() – Sets Camera’s current AGC ROI to
            //     agcROI –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcROI(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ROI_T_PTR
            //     agcROIPtr) LEP_RESULT LEP_SetAgcROI(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ROI_T
            //     agcROI) /* AGC ROI Structure */ typedef struct LEP_AGC_ROI_TAG { LEP_UINT16 startCol;
            //     LEP_UINT16 startRow; LEP_UINT16 endCol; LEP_UINT16 endRow; }LEP_AGC_ROI_T, *LEP_AGC_ROI_T_PTR;
            public Roi GetROI();
            //
            // Сводка:
            //     AGC ROI Select
            //     The AGC algorithms utilize a histogram, which is collected from within a specified
            //     rectangular window or Region of Interest (ROI). This region is defined by 4 parameters:
            //     start column, start row, end column, and end row. The region is adjustable from
            //     full window to a sub-window.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Value – Units – Scale factor –
            //     start column
            //     – 0 – < = endCol – 0 – pixels – 1 –
            //     start row
            //     – 0 – < endRow – 0 – pixels – 1 –
            //     end column
            //     – >= startCol – 79 – 79 – pixels – 1 –
            //     end row
            //     – >= startRow – 59 – 59 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Value – Units – Scale factor –
            //     start column
            //     – 0 – < = endCol – 0 – pixels – 1 –
            //     start row
            //     – 0 – < endRow – 0 – pixels – 1 –
            //     end column
            //     – >= startCol – 159 – 159 – pixels – 1 –
            //     end row
            //     – >= startRow – 119 – 119 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x08
            //     With Set 0x09
            //     SDK Data Length: Get 4 size of LEP_AGC_ROI_T data type
            //     Set 4 size of LEP_AGC_ROI_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcROI() – Updates agcROIPtr with the Camera’s
            //     current AGC ROI –
            //     All Lepton Configurations – LEP_SetAgcROI() – Sets Camera’s current AGC ROI to
            //     agcROI –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcROI(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ROI_T_PTR
            //     agcROIPtr) LEP_RESULT LEP_SetAgcROI(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ROI_T
            //     agcROI) /* AGC ROI Structure */ typedef struct LEP_AGC_ROI_TAG { LEP_UINT16 startCol;
            //     LEP_UINT16 startRow; LEP_UINT16 endCol; LEP_UINT16 endRow; }LEP_AGC_ROI_T, *LEP_AGC_ROI_T_PTR;
            public Roi GetROIChecked();
            //
            // Сводка:
            //     AGC Calculation Enable State
            //     This parameter controls the camera AGC calculations operations. If enabled, the
            //     current video histogram and AGC policy will be calculated for each input frame.
            //     If disabled, then no AGC calculations are performed and the current state of
            //     the ITT is preserved. For smooth AGC on /off operation, it is recommended to
            //     have this enabled.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_DISABLE – LEP_AGC_ENABLE – LEP_AGC_DISABLE – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x48
            //     With Set 0x49
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcCalcEnableState() – Updates agcCalculationEnableStatePtr
            //     with the Camera’s current AGC Calculation enable state –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcCalcEnableState() – Sets Camera’s current
            //     AGC Calculation enable state to agcCalculationEnableState –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcCalcEnableState( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_ENABLE_E_PTR agcCalculationEnableStatePtr ) LEP_RESULT LEP_SetAgcCalcEnableState(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ENABLE_E agcCalculationEnableState
            //     ) /* AGC Enable Enum */ typedef enum LEP_AGC_ENABLE_TAG { LEP_AGC_DISABLE=0,
            //     LEP_AGC_ENABLE, LEP_END_AGC_ENABLE }LEP_AGC_ENABLE_E, *LEP_AGC_ENABLE_E_PTR;
            public void SetCalcEnableState(Enable source);
            //
            // Сводка:
            //     AGC Calculation Enable State
            //     This parameter controls the camera AGC calculations operations. If enabled, the
            //     current video histogram and AGC policy will be calculated for each input frame.
            //     If disabled, then no AGC calculations are performed and the current state of
            //     the ITT is preserved. For smooth AGC on /off operation, it is recommended to
            //     have this enabled.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_DISABLE – LEP_AGC_ENABLE – LEP_AGC_DISABLE – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x48
            //     With Set 0x49
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcCalcEnableState() – Updates agcCalculationEnableStatePtr
            //     with the Camera’s current AGC Calculation enable state –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcCalcEnableState() – Sets Camera’s current
            //     AGC Calculation enable state to agcCalculationEnableState –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcCalcEnableState( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_ENABLE_E_PTR agcCalculationEnableStatePtr ) LEP_RESULT LEP_SetAgcCalcEnableState(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ENABLE_E agcCalculationEnableState
            //     ) /* AGC Enable Enum */ typedef enum LEP_AGC_ENABLE_TAG { LEP_AGC_DISABLE=0,
            //     LEP_AGC_ENABLE, LEP_END_AGC_ENABLE }LEP_AGC_ENABLE_E, *LEP_AGC_ENABLE_E_PTR;
            public void SetCalcEnableStateChecked(Enable source);
            //
            // Сводка:
            //     AGC Enable and Disable
            //     To turn AGC ON is to enable AGC processing. Disabling the AGC will turn the AGC
            //     processing OFF and the video data will not be optimized for scene contrast. This
            //     command sets and retrieves the AGC state.
            //     Note that the Focus metric (see 4.5.3) must be disabled when AGC is enabled.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_DISABLE – LEP_AGC_ENABLE – LEP_AGC_DISABLE – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base 0x00
            //     With Get 0x00
            //     With Set 0x01
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcEnableState() – Updates agcEnableStatePtr
            //     with the Camera’s current AGC enable state. –
            //     All Lepton Configurations – LEP_SetAgcEnableState() – Sets Camera’s current AGC
            //     enable state to agcEnableState –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ENABLE_E_PTR
            //     agcEnableStatePtr) LEP_RESULT LEP_SetAgcEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_AGC_ENABLE_E agcEnableState) /* AGC Enable Enum */ typedef enum
            //     LEP_AGC_ENABLE_TAG { LEP_AGC_DISABLE=0, LEP_AGC_ENABLE, LEP_END_AGC_ENABLE }LEP_AGC_ENABLE_E,
            //     *LEP_AGC_ENABLE_E_PTR;
            public void SetEnableState(Enable source);
            //
            // Сводка:
            //     AGC Enable and Disable
            //     To turn AGC ON is to enable AGC processing. Disabling the AGC will turn the AGC
            //     processing OFF and the video data will not be optimized for scene contrast. This
            //     command sets and retrieves the AGC state.
            //     Note that the Focus metric (see 4.5.3) must be disabled when AGC is enabled.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_DISABLE – LEP_AGC_ENABLE – LEP_AGC_DISABLE – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base 0x00
            //     With Get 0x00
            //     With Set 0x01
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcEnableState() – Updates agcEnableStatePtr
            //     with the Camera’s current AGC enable state. –
            //     All Lepton Configurations – LEP_SetAgcEnableState() – Sets Camera’s current AGC
            //     enable state to agcEnableState –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ENABLE_E_PTR
            //     agcEnableStatePtr) LEP_RESULT LEP_SetAgcEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_AGC_ENABLE_E agcEnableState) /* AGC Enable Enum */ typedef enum
            //     LEP_AGC_ENABLE_TAG { LEP_AGC_DISABLE=0, LEP_AGC_ENABLE, LEP_END_AGC_ENABLE }LEP_AGC_ENABLE_E,
            //     *LEP_AGC_ENABLE_E_PTR;
            public void SetEnableStateChecked(Enable source);
            public void SetHeqBinExtension(ushort source);
            public void SetHeqBinExtensionChecked(ushort source);
            //
            // Сводка:
            //     AGC HEQ Clip Limit High
            //     This parameter defines the maximum number of pixels allowed to accumulate in
            //     any given histogram bin. Any additional pixels in a given bin are clipped. The
            //     effect of this parameter is to limit the influence of highly-populated bins on
            //     the resulting HEQ transformation function.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 4,800 – 4,800 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 19,200 – 19,200 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x2C
            //     With Set 0x2D
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcHeqClipLimitHigh() – Updates agcHeqClipLimitHighPtr
            //     with the Camera’s current HEQ level high value –
            //     All Lepton Configurations – LEP_SetAgcHeqClipLimitHigh() – Sets Camera’s current
            //     HEQ level high value to agcHeqClipLimitHigh –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqClipLimitHigh(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqClipLimitHighPtr) LEP_RESULT LEP_SetAgcHeqClipLimitHigh(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 agcHeqClipLimitHigh)
            public void SetHeqClipLimitHigh(ushort source);
            //
            // Сводка:
            //     AGC HEQ Clip Limit High
            //     This parameter defines the maximum number of pixels allowed to accumulate in
            //     any given histogram bin. Any additional pixels in a given bin are clipped. The
            //     effect of this parameter is to limit the influence of highly-populated bins on
            //     the resulting HEQ transformation function.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 4,800 – 4,800 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 19,200 – 19,200 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x2C
            //     With Set 0x2D
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcHeqClipLimitHigh() – Updates agcHeqClipLimitHighPtr
            //     with the Camera’s current HEQ level high value –
            //     All Lepton Configurations – LEP_SetAgcHeqClipLimitHigh() – Sets Camera’s current
            //     HEQ level high value to agcHeqClipLimitHigh –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqClipLimitHigh(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqClipLimitHighPtr) LEP_RESULT LEP_SetAgcHeqClipLimitHigh(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 agcHeqClipLimitHigh)
            public void SetHeqClipLimitHighChecked(ushort source);
            //
            // Сводка:
            //     AGC HEQ Clip Limit Low
            //     This parameter defines an artificial population that is added to every non-empty
            //     histogram bin. In other words, if the Clip Limit Low is set to L, a bin with
            //     an actual population of X will have an effective population of L + X. y empty
            //     bin that is nearby a populated bin will be given an artificial population of
            //     L. The effect of higher values is to provide a more linear transfer function;
            //     lower values provide a more non-linear (equalized) transfer function. This command
            //     is deprecated for Lepton 3 (replaced by Linear Percent).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 1024 – 512 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x30
            //     With Set 0x31
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcHeqClipLimitLow() – Updates agcHeqClipLimitLowPtr
            //     with the Camera’s current HEQ level Low value –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcHeqClipLimitLow() – Sets Camera’s current
            //     HEQ level Low value to agcHeqClipLimitLow –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqClipLimitLow(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqClipLimitLowPtr) LEP_RESULT LEP_SetAgcHeqClipLimitLow(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 agcHeqClipLimitLow)
            public void SetHeqClipLimitLow(ushort source);
            //
            // Сводка:
            //     AGC HEQ Clip Limit Low
            //     This parameter defines an artificial population that is added to every non-empty
            //     histogram bin. In other words, if the Clip Limit Low is set to L, a bin with
            //     an actual population of X will have an effective population of L + X. y empty
            //     bin that is nearby a populated bin will be given an artificial population of
            //     L. The effect of higher values is to provide a more linear transfer function;
            //     lower values provide a more non-linear (equalized) transfer function. This command
            //     is deprecated for Lepton 3 (replaced by Linear Percent).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 1024 – 512 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x30
            //     With Set 0x31
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcHeqClipLimitLow() – Updates agcHeqClipLimitLowPtr
            //     with the Camera’s current HEQ level Low value –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcHeqClipLimitLow() – Sets Camera’s current
            //     HEQ level Low value to agcHeqClipLimitLow –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqClipLimitLow(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqClipLimitLowPtr) LEP_RESULT LEP_SetAgcHeqClipLimitLow(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 agcHeqClipLimitLow)
            public void SetHeqClipLimitLowChecked(ushort source);
            //
            // Сводка:
            //     AGC HEQ Dampening Factor
            //     This parameter is the amount of temporal dampening applied to the HEQ transformation
            //     function. An IIR filter of the form (N/256) * previous + ((256-N)/256) * current
            //     is applied , and the HEQ dampening factor represents the value N in the equation,
            //     i.e., a value that applies to the amount of influence the previous HEQ transformation
            //     function has on the current function. . The lower the value of N the higher the
            //     influence of the current video frame whereas the higher the value of N the more
            //     influence the previous damped transfer function has.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 256 – 64 – N/A – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcHeqDampingFactor() – Updates agcHeqDampingFactorPtr
            //     with the Camera’s current HEQ dampening factor –
            //     All Lepton Configurations – LEP_SetAgcHeqDampingFactor() – Sets Camera’s current
            //     HEQ dampening factor to agcHeqDampingFactor –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqDampingFactor(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqDampingFactorPtr) LEP_RESULT LEP_SetAgcHeqDampingFactor(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 gcHeqDampingFactor)
            public void SetHeqDampingFactor(ushort source);
            //
            // Сводка:
            //     AGC HEQ Dampening Factor
            //     This parameter is the amount of temporal dampening applied to the HEQ transformation
            //     function. An IIR filter of the form (N/256) * previous + ((256-N)/256) * current
            //     is applied , and the HEQ dampening factor represents the value N in the equation,
            //     i.e., a value that applies to the amount of influence the previous HEQ transformation
            //     function has on the current function. . The lower the value of N the higher the
            //     influence of the current video frame whereas the higher the value of N the more
            //     influence the previous damped transfer function has.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 256 – 64 – N/A – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcHeqDampingFactor() – Updates agcHeqDampingFactorPtr
            //     with the Camera’s current HEQ dampening factor –
            //     All Lepton Configurations – LEP_SetAgcHeqDampingFactor() – Sets Camera’s current
            //     HEQ dampening factor to agcHeqDampingFactor –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqDampingFactor(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqDampingFactorPtr) LEP_RESULT LEP_SetAgcHeqDampingFactor(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 gcHeqDampingFactor)
            public void SetHeqDampingFactorChecked(ushort source);
            //
            // Сводка:
            //     AGC HEQ Empty Counts
            //     This parameter specifies the maximum number of pixels in a bin that will be interpreted
            //     as an empty bin. Histogram bins with this number of pixels or less will be processed
            //     as an empty bin.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 2^14 -1 – 2 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x3C
            //     With Set 0x3D
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcHeqEmptyCount() – Updates emptyCountPtr
            //     with the Camera’s current HEQ transfer function’s bin empty count –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcHeqEmptyCount() – Sets Camera’s current
            //     HEQ transfer function’s bin empty count to emptyCount –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqEmptyCount(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_HEQ_EMPTY_COUNT_T_PTR
            //     emptyCountPtr) LEP_RESULT LEP_SetAgcHeqEmptyCount(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_AGC_HEQ_EMPTY_COUNT_T emptyCount)
            public void SetHeqEmptyCount(ushort source);
            //
            // Сводка:
            //     AGC HEQ Empty Counts
            //     This parameter specifies the maximum number of pixels in a bin that will be interpreted
            //     as an empty bin. Histogram bins with this number of pixels or less will be processed
            //     as an empty bin.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 2^14 -1 – 2 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x3C
            //     With Set 0x3D
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcHeqEmptyCount() – Updates emptyCountPtr
            //     with the Camera’s current HEQ transfer function’s bin empty count –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcHeqEmptyCount() – Sets Camera’s current
            //     HEQ transfer function’s bin empty count to emptyCount –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqEmptyCount(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_HEQ_EMPTY_COUNT_T_PTR
            //     emptyCountPtr) LEP_RESULT LEP_SetAgcHeqEmptyCount(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_AGC_HEQ_EMPTY_COUNT_T emptyCount)
            public void SetHeqEmptyCountChecked(ushort source);
            //
            // Сводка:
            //     AGC HEQ Linear Percent
            //     This parameter controls the camera AGC HEQ algorithm’s linear percent. The linear
            //     percent parameter fills holes in the histogram with pixels to avoid undesirable
            //     compression in 8-bit irradiance levels. Similar to the low clip limit, pixels
            //     are added to each full bin and to an additional number of empty bins following
            //     full bins. The linear percent parameter is more automatic than allowing the user
            //     to specify the low clip limit; the linear percent adjusts low clip limit based
            //     on the scene content and the desired percentage of total pixels in the histogram.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 100 – 20 – percent – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x4C
            //     With Set 0x4D
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 3.0 – LEP_GetAgcHeqLinearPercent() – Updates agcHeqLinearPercentPtr with
            //     the Camera’s current AGC HEQ Linear Percent value –
            //     Lepton 3.0 – LEP_SetAgcHeqLinearPercent() – Sets Camera’s current AGC HEQ Linear
            //     Percent to agcHeqLinearPercent –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqLinearPercent( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqLinearPercentPtr) LEP_RESULT LEP_SetAgcHeqLinearPercent( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 agcHeqLinearPercent)
            public void SetHeqLinearPercent(ushort source);
            //
            // Сводка:
            //     AGC HEQ Linear Percent
            //     This parameter controls the camera AGC HEQ algorithm’s linear percent. The linear
            //     percent parameter fills holes in the histogram with pixels to avoid undesirable
            //     compression in 8-bit irradiance levels. Similar to the low clip limit, pixels
            //     are added to each full bin and to an additional number of empty bins following
            //     full bins. The linear percent parameter is more automatic than allowing the user
            //     to specify the low clip limit; the linear percent adjusts low clip limit based
            //     on the scene content and the desired percentage of total pixels in the histogram.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 100 – 20 – percent – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x4C
            //     With Set 0x4D
            //     SDK Data Length: Get 1 size of LEP_UINT16 data type
            //     Set 1 size of LEP_UINT16 data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 3.0 – LEP_GetAgcHeqLinearPercent() – Updates agcHeqLinearPercentPtr with
            //     the Camera’s current AGC HEQ Linear Percent value –
            //     Lepton 3.0 – LEP_SetAgcHeqLinearPercent() – Sets Camera’s current AGC HEQ Linear
            //     Percent to agcHeqLinearPercent –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqLinearPercent( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_UINT16 *agcHeqLinearPercentPtr) LEP_RESULT LEP_SetAgcHeqLinearPercent( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT16 agcHeqLinearPercent)
            public void SetHeqLinearPercentChecked(ushort source);
            public void SetHeqMaxGain(ushort source);
            public void SetHeqMaxGainChecked(ushort source);
            public void SetHeqMidPoint(ushort source);
            public void SetHeqMidPointChecked(ushort source);
            public void SetHeqNormalizationFactor(ushort source);
            public void SetHeqNormalizationFactorChecked(ushort source);
            //
            // Сводка:
            //     AGC HEQ Output Scale Factor
            //     This parameter specifies the output format for HEQ as either 8-bits (values range
            //     0 to 255), or 14-bit (values range from 0 to 16383).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_SCALE_TO_8_BITS – LEP_AGC_SCALE_TO_14_BITS – LEP_AGC_SCALE_TO_8_BITS
            //     – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x44
            //     With Set 0x45
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcHeqScaleFactor() – Updates scaleFactorPtr
            //     with the Camera’s current AGC HEQ Output Scale Factor –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcHeqScaleFactor() – Sets Camera’s current
            //     AGC HEQ Output Scale Factor to scaleFactor –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqScaleFactor (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_HEQ_SCALE_FACTOR_E_PTR scaleFactorPtr) LEP_RESULT LEP_SetAgcHeqScaleFactor
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_HEQ_SCALE_FACTOR_E scaleFactor)
            //     /* AGC Output Scale Factor Structure */ typedef enum LEP_AGC_SCALE_FACTOR_E_TAG
            //     { LEP_AGC_SCALE_TO_8_BITS = 0, LEP_AGC_SCALE_TO_14_BITS, LEP_AGC_END_SCALE_TO
            //     }LEP_AGC_HEQ_SCALE_FACTOR_E, *LEP_AGC_HEQ_SCALE_FACTOR_E_PTR;
            public void SetHeqScaleFactor(HeqScaleFactor source);
            //
            // Сводка:
            //     AGC HEQ Output Scale Factor
            //     This parameter specifies the output format for HEQ as either 8-bits (values range
            //     0 to 255), or 14-bit (values range from 0 to 16383).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_SCALE_TO_8_BITS – LEP_AGC_SCALE_TO_14_BITS – LEP_AGC_SCALE_TO_8_BITS
            //     – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x44
            //     With Set 0x45
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_GetAgcHeqScaleFactor() – Updates scaleFactorPtr
            //     with the Camera’s current AGC HEQ Output Scale Factor –
            //     Lepton 1.5, 1.6, 2.0, 2.5 – LEP_SetAgcHeqScaleFactor() – Sets Camera’s current
            //     AGC HEQ Output Scale Factor to scaleFactor –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcHeqScaleFactor (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_HEQ_SCALE_FACTOR_E_PTR scaleFactorPtr) LEP_RESULT LEP_SetAgcHeqScaleFactor
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_HEQ_SCALE_FACTOR_E scaleFactor)
            //     /* AGC Output Scale Factor Structure */ typedef enum LEP_AGC_SCALE_FACTOR_E_TAG
            //     { LEP_AGC_SCALE_TO_8_BITS = 0, LEP_AGC_SCALE_TO_14_BITS, LEP_AGC_END_SCALE_TO
            //     }LEP_AGC_HEQ_SCALE_FACTOR_E, *LEP_AGC_HEQ_SCALE_FACTOR_E_PTR;
            public void SetHeqScaleFactorChecked(HeqScaleFactor source);
            public void SetLinearDampeningFactor(ushort source);
            public void SetLinearDampeningFactorChecked(ushort source);
            public void SetLinearHistogramClipPercent(ushort source);
            public void SetLinearHistogramClipPercentChecked(ushort source);
            public void SetLinearHistogramTailSize(ushort source);
            public void SetLinearHistogramTailSizeChecked(ushort source);
            public void SetLinearMaxGain(ushort source);
            public void SetLinearMaxGainChecked(ushort source);
            public void SetLinearMidPoint(ushort source);
            public void SetLinearMidPointChecked(ushort source);
            //
            // Сводка:
            //     AGC Policy Select
            //     The camera supports 2 AGC policies to process incoming video data, histogram
            //     equalization (HEQ) and linear histogram stretch. This command sets and retrieves
            //     the AGC policy.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_LINEAR – LEP_AGC_HEQ – LEP_AGC_HEQ – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x04
            //     With Set 0x05
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcPolicy() – Updates agcPolicyPtr with the
            //     Camera’s current AGC policy. –
            //     All Lepton Configurations – LEP_SetAgcPolicy() – Sets Camera’s current AGC policy
            //     to agcPolicy. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcPolicy(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_POLICY_E_PTR
            //     agcPolicyPtr) LEP_RESULT LEP_SetAgcPolicy(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_POLICY_E agcPolicy) /* AGC Policy Enum */ typedef enum LEP_AGC_POLICY_TAG
            //     { LEP_AGC_LINEAR=0, LEP_AGC_HEQ, LEP_END_AGC_POLICY }LEP_AGC_POLICY_E, *LEP_AGC_POLICY_E_PTR;
            public void SetPolicy(Policy source);
            //
            // Сводка:
            //     AGC Policy Select
            //     The camera supports 2 AGC policies to process incoming video data, histogram
            //     equalization (HEQ) and linear histogram stretch. This command sets and retrieves
            //     the AGC policy.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_AGC_LINEAR – LEP_AGC_HEQ – LEP_AGC_HEQ – N/A – N/A –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x04
            //     With Set 0x05
            //     SDK Data Length: Get 2 size on an enum data type on a 32-bit machine
            //     Set 2 size on an enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcPolicy() – Updates agcPolicyPtr with the
            //     Camera’s current AGC policy. –
            //     All Lepton Configurations – LEP_SetAgcPolicy() – Sets Camera’s current AGC policy
            //     to agcPolicy. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcPolicy(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_POLICY_E_PTR
            //     agcPolicyPtr) LEP_RESULT LEP_SetAgcPolicy(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_AGC_POLICY_E agcPolicy) /* AGC Policy Enum */ typedef enum LEP_AGC_POLICY_TAG
            //     { LEP_AGC_LINEAR=0, LEP_AGC_HEQ, LEP_END_AGC_POLICY }LEP_AGC_POLICY_E, *LEP_AGC_POLICY_E_PTR;
            public void SetPolicyChecked(Policy source);
            //
            // Сводка:
            //     AGC ROI Select
            //     The AGC algorithms utilize a histogram, which is collected from within a specified
            //     rectangular window or Region of Interest (ROI). This region is defined by 4 parameters:
            //     start column, start row, end column, and end row. The region is adjustable from
            //     full window to a sub-window.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Value – Units – Scale factor –
            //     start column
            //     – 0 – < = endCol – 0 – pixels – 1 –
            //     start row
            //     – 0 – < endRow – 0 – pixels – 1 –
            //     end column
            //     – >= startCol – 79 – 79 – pixels – 1 –
            //     end row
            //     – >= startRow – 59 – 59 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Value – Units – Scale factor –
            //     start column
            //     – 0 – < = endCol – 0 – pixels – 1 –
            //     start row
            //     – 0 – < endRow – 0 – pixels – 1 –
            //     end column
            //     – >= startCol – 159 – 159 – pixels – 1 –
            //     end row
            //     – >= startRow – 119 – 119 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x08
            //     With Set 0x09
            //     SDK Data Length: Get 4 size of LEP_AGC_ROI_T data type
            //     Set 4 size of LEP_AGC_ROI_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcROI() – Updates agcROIPtr with the Camera’s
            //     current AGC ROI –
            //     All Lepton Configurations – LEP_SetAgcROI() – Sets Camera’s current AGC ROI to
            //     agcROI –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcROI(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ROI_T_PTR
            //     agcROIPtr) LEP_RESULT LEP_SetAgcROI(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ROI_T
            //     agcROI) /* AGC ROI Structure */ typedef struct LEP_AGC_ROI_TAG { LEP_UINT16 startCol;
            //     LEP_UINT16 startRow; LEP_UINT16 endCol; LEP_UINT16 endRow; }LEP_AGC_ROI_T, *LEP_AGC_ROI_T_PTR;
            public void SetROI(Roi source);
            //
            // Сводка:
            //     AGC ROI Select
            //     The AGC algorithms utilize a histogram, which is collected from within a specified
            //     rectangular window or Region of Interest (ROI). This region is defined by 4 parameters:
            //     start column, start row, end column, and end row. The region is adjustable from
            //     full window to a sub-window.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Value – Units – Scale factor –
            //     start column
            //     – 0 – < = endCol – 0 – pixels – 1 –
            //     start row
            //     – 0 – < endRow – 0 – pixels – 1 –
            //     end column
            //     – >= startCol – 79 – 79 – pixels – 1 –
            //     end row
            //     – >= startRow – 59 – 59 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Value – Units – Scale factor –
            //     start column
            //     – 0 – < = endCol – 0 – pixels – 1 –
            //     start row
            //     – 0 – < endRow – 0 – pixels – 1 –
            //     end column
            //     – >= startCol – 159 – 159 – pixels – 1 –
            //     end row
            //     – >= startRow – 119 – 119 – pixels – 1 –
            //     SDK Module ID: AGC 0x0100
            //     SDK Command ID: Base With Get 0x08
            //     With Set 0x09
            //     SDK Data Length: Get 4 size of LEP_AGC_ROI_T data type
            //     Set 4 size of LEP_AGC_ROI_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetAgcROI() – Updates agcROIPtr with the Camera’s
            //     current AGC ROI –
            //     All Lepton Configurations – LEP_SetAgcROI() – Sets Camera’s current AGC ROI to
            //     agcROI –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetAgcROI(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ROI_T_PTR
            //     agcROIPtr) LEP_RESULT LEP_SetAgcROI(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_AGC_ROI_T
            //     agcROI) /* AGC ROI Structure */ typedef struct LEP_AGC_ROI_TAG { LEP_UINT16 startCol;
            //     LEP_UINT16 startRow; LEP_UINT16 endCol; LEP_UINT16 endRow; }LEP_AGC_ROI_T, *LEP_AGC_ROI_T_PTR;
            public void SetROIChecked(Roi source);

            public enum Enable
            {
                DISABLE = 0,
                ENABLE = 1
            }
            public enum Policy
            {
                LINEAR = 0,
                HEQ = 1
            }
            public enum HeqScaleFactor
            {
                SCALE_TO_8_BITS = 0,
                SCALE_TO_14_BITS = 1
            }

            public class Roi
            {
                public ushort startCol;
                public ushort startRow;
                public ushort endCol;
                public ushort endRow;

                public Roi(ushort startCol, ushort startRow, ushort endCol, ushort endRow);

                public override string ToString();
            }
            public class HistogramStatistics
            {
                public ushort minIntensity;
                public ushort maxIntensity;
                public ushort meanIntensity;
                public ushort numPixels;

                public HistogramStatistics(ushort minIntensity, ushort maxIntensity, ushort meanIntensity, ushort numPixels);

                public override string ToString();
            }
        }
        //
        // Сводка:
        //     This module provides additional camera configuration, control, information and
        //     status of the camera system. This includes more specific version information
        //     about the camera. This module also provides OEMs with filter controls, power
        //     controls, and video output configuration and control.
        public class Oem
        {
            public Oem(UVC port);

            //
            // Сводка:
            //     OEM Bad Pixel Replacement Control
            //     This function enables or disables the camera’s bad pixel replacement control.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x6C
            //     With Set 0x6D
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemBadPixelReplaceControl() – Updates BadPixelReplaceControlPtrwith
            //     the Camera’s current bad pixel replacement control enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemBadPixelReplaceControl() – Updates the Camera’s
            //     current bad pixel replacement control enable state with the contents of BadPixelReplaceControl.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemBadPixelReplaceControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T_PTR BadPixelReplaceControlPtr ) LEP_RESULT
            //     LEP_SetOemBadPixelReplaceControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T
            //     BadPixelReplaceControl ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG
            //     { LEP_OEM_DISABLE = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Bad Pixel Replacement Control structure */ typedef struct LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T_TAG
            //     { LEP_OEM_STATE_E oemBadPixelReplaceEnable; }LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T,
            //     *LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T_PTR;
            public BadPixelReplaceControl GetBadPixelReplaceControl();
            //
            // Сводка:
            //     OEM Bad Pixel Replacement Control
            //     This function enables or disables the camera’s bad pixel replacement control.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x6C
            //     With Set 0x6D
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemBadPixelReplaceControl() – Updates BadPixelReplaceControlPtrwith
            //     the Camera’s current bad pixel replacement control enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemBadPixelReplaceControl() – Updates the Camera’s
            //     current bad pixel replacement control enable state with the contents of BadPixelReplaceControl.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemBadPixelReplaceControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T_PTR BadPixelReplaceControlPtr ) LEP_RESULT
            //     LEP_SetOemBadPixelReplaceControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T
            //     BadPixelReplaceControl ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG
            //     { LEP_OEM_DISABLE = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Bad Pixel Replacement Control structure */ typedef struct LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T_TAG
            //     { LEP_OEM_STATE_E oemBadPixelReplaceEnable; }LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T,
            //     *LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T_PTR;
            public BadPixelReplaceControl GetBadPixelReplaceControlChecked();
            //
            // Сводка:
            //     OEM Status
            //     This function obtains the current status of an OEM run operation. This function
            //     is used whenever an OEM command is issued that executes an operation like the
            //     run FFC. Typically, the host polls the status to determine when the command has
            //     completed. If the return value is negative, then the operation completed with
            //     an error. Positive values indicate an in-process state. Zero indicates the operation
            //     completed without error.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_STATUS_OTP_WRITE_ERROR – LEP_OEM_FRAME_AVERAGE_COLLECTING_FRAMES – LEP_OEM_STATUS_READY
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x48
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemCalStatus() – Gets the Current OEM operation
            //     status. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemCalStatus( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_STATUS_E_PTR
            //     calStatusPtr ) typedef enum { LEP_OEM_STATUS_OTP_WRITE_ERROR = -2, LEP_OEM_STATUS_ERROR
            //     = -1, LEP_OEM_STATUS_READY = 0, LEP_OEM_STATUS_BUSY, LEP_OEM_FRAME_AVERAGE_COLLECTING_FRAMES,
            //     LEP_OEM_STATUS_END } LEP_OEM_STATUS_E, *LEP_OEM_STATUS_E_PTR;
            public Status GetCalStatus();
            //
            // Сводка:
            //     OEM Status
            //     This function obtains the current status of an OEM run operation. This function
            //     is used whenever an OEM command is issued that executes an operation like the
            //     run FFC. Typically, the host polls the status to determine when the command has
            //     completed. If the return value is negative, then the operation completed with
            //     an error. Positive values indicate an in-process state. Zero indicates the operation
            //     completed without error.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_STATUS_OTP_WRITE_ERROR – LEP_OEM_FRAME_AVERAGE_COLLECTING_FRAMES – LEP_OEM_STATUS_READY
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x48
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemCalStatus() – Gets the Current OEM operation
            //     status. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemCalStatus( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_STATUS_E_PTR
            //     calStatusPtr ) typedef enum { LEP_OEM_STATUS_OTP_WRITE_ERROR = -2, LEP_OEM_STATUS_ERROR
            //     = -1, LEP_OEM_STATUS_READY = 0, LEP_OEM_STATUS_BUSY, LEP_OEM_FRAME_AVERAGE_COLLECTING_FRAMES,
            //     LEP_OEM_STATUS_END } LEP_OEM_STATUS_E, *LEP_OEM_STATUS_E_PTR;
            public Status GetCalStatusChecked();
            //
            // Сводка:
            //     OEM Column Noise Filter (SCNR) Control
            //     This function enables or disables the camera’s column noise filter.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x74
            //     With Set 0x75
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemColumnNoiseEstimateControl() – Updates ColumnNoiseEstimateControlPtr
            //     the Camera’s current column noise filter enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemColumnNoiseEstimateControl() – Updates the Camera’s
            //     current column noise filter enable state with the contents of ColumnNoiseEstimateControl.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemColumnNoiseEstimateControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T_PTR ColumnNoiseEstimateControlPtr ) LEP_RESULT
            //     LEP_SetOemColumnNoiseEstimateControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T ColumnNoiseEstimateControl ) /* Enable
            //     State Enum */ typedef enum LEP_OEM_STATE_E_TAG { LEP_OEM_DISABLE = 0, LEP_OEM_ENABLE,
            //     LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR; /* Column Noise Filter
            //     Control structure */ typedef struct LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T_TAG
            //     { LEP_OEM_STATE_E oemColumnNoiseEstimateEnable; }LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T,
            //     *LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T_PTR;
            public ColumnNoiseEstimateControl GetColumnNoiseEstimateControl();
            //
            // Сводка:
            //     OEM Column Noise Filter (SCNR) Control
            //     This function enables or disables the camera’s column noise filter.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x74
            //     With Set 0x75
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemColumnNoiseEstimateControl() – Updates ColumnNoiseEstimateControlPtr
            //     the Camera’s current column noise filter enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemColumnNoiseEstimateControl() – Updates the Camera’s
            //     current column noise filter enable state with the contents of ColumnNoiseEstimateControl.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemColumnNoiseEstimateControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T_PTR ColumnNoiseEstimateControlPtr ) LEP_RESULT
            //     LEP_SetOemColumnNoiseEstimateControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T ColumnNoiseEstimateControl ) /* Enable
            //     State Enum */ typedef enum LEP_OEM_STATE_E_TAG { LEP_OEM_DISABLE = 0, LEP_OEM_ENABLE,
            //     LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR; /* Column Noise Filter
            //     Control structure */ typedef struct LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T_TAG
            //     { LEP_OEM_STATE_E oemColumnNoiseEstimateEnable; }LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T,
            //     *LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T_PTR;
            public ColumnNoiseEstimateControl GetColumnNoiseEstimateControlChecked();
            //
            // Сводка:
            //     OEM Customer Part Number
            //     This function gets the Customer Part Number. This part number is previously written
            //     into the Camera OTP during factory calibration.
            //     The Customer Part Number is a 32-byte string identifier unique to a specific
            //     configuration of the Camera module.
            //     This command requires the Host to allocate the memory buffer before calling this
            //     function. The address to this memory block should be passed in as oemPartNumberPtr
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x38
            //     SDK Data Length: Get 16 32-byte string
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemCustPartNumber() – Updates oemPartNumberPtr
            //     with the Camera’s current Customer Part Number. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemCustPartNumber( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_PART_NUMBER_T_PTR oemPartNumberPtr ) /* Part Number: A (32 byte string)
            //     identifier unique to a ** Specific configuration of module; essentially a module
            //     ** Configuration ID. */ typedef LEP_CHAR8 *LEP_OEM_PART_NUMBER_T, *LEP_OEM_PART_NUMBER_T_PTR;
            public PartNumber GetCustPartNumber();
            //
            // Сводка:
            //     OEM Customer Part Number
            //     This function gets the Customer Part Number. This part number is previously written
            //     into the Camera OTP during factory calibration.
            //     The Customer Part Number is a 32-byte string identifier unique to a specific
            //     configuration of the Camera module.
            //     This command requires the Host to allocate the memory buffer before calling this
            //     function. The address to this memory block should be passed in as oemPartNumberPtr
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x38
            //     SDK Data Length: Get 16 32-byte string
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemCustPartNumber() – Updates oemPartNumberPtr
            //     with the Camera’s current Customer Part Number. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemCustPartNumber( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_PART_NUMBER_T_PTR oemPartNumberPtr ) /* Part Number: A (32 byte string)
            //     identifier unique to a ** Specific configuration of module; essentially a module
            //     ** Configuration ID. */ typedef LEP_CHAR8 *LEP_OEM_PART_NUMBER_T, *LEP_OEM_PART_NUMBER_T_PTR;
            public PartNumber GetCustPartNumberChecked();
            //
            // Сводка:
            //     OEM FFC Normalization Target
            //     The first two of these commands Get and Set the Flat-Field Correction (FFC) Normalization
            //     Target used by the third command to execute a Flat-Field Correction (FFC). The
            //     target value is factory set and should not be changed under normal circumstances.
            //     The Run command executes an FFC using currently active values for the FFC normalization
            //     target and number of frames to average (see 4.4.21). This command executes synchronously.
            //     Poll the OEM Status to determine when this command completes (see 4.6.13).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 16383 – 8192 – N/A – N/A –
            //     SDK Module ID: SYS 0x0800
            //     SDK Command ID: Base With Get 0x44 With Set With Run 0x46
            //     SDK Data Length: Get 1 size of a LEP_UINT16 Set 1 size of a Run 0 size of a Run
            //     command
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemFFCNormalizationTarget() – Gets the normalization
            //     target –
            //     All Lepton Configurations – LEP_SetOemFFCNormalizationTarget() – Sets the normalization
            //     target –
            //     All Lepton Configurations – LEP_RunOemFFC() – Executes the FFC normalization
            //     using previously specified normalization target value –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemFFCNormalizationTarget( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_FFC_NORMALIZATION_TARGET_T_PTR ffcTargetPtr ) LEP_RESULT LEP_SetOemFFCNormalizationTarget(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_FFC_NORMALIZATION_TARGET_T ffcTarget
            //     ) LEP_RESULT LEP_RunOemFFC typedef LEP_UINT16 LEP_OEM_FFC_NORMALIZATION_TARGET_T,
            //     *LEP_OEM_FFC_NORMALIZATION_TARGET_T_PTR;
            public ushort GetFFCNormalizationTarget();
            //
            // Сводка:
            //     OEM FFC Normalization Target
            //     The first two of these commands Get and Set the Flat-Field Correction (FFC) Normalization
            //     Target used by the third command to execute a Flat-Field Correction (FFC). The
            //     target value is factory set and should not be changed under normal circumstances.
            //     The Run command executes an FFC using currently active values for the FFC normalization
            //     target and number of frames to average (see 4.4.21). This command executes synchronously.
            //     Poll the OEM Status to determine when this command completes (see 4.6.13).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 16383 – 8192 – N/A – N/A –
            //     SDK Module ID: SYS 0x0800
            //     SDK Command ID: Base With Get 0x44 With Set With Run 0x46
            //     SDK Data Length: Get 1 size of a LEP_UINT16 Set 1 size of a Run 0 size of a Run
            //     command
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemFFCNormalizationTarget() – Gets the normalization
            //     target –
            //     All Lepton Configurations – LEP_SetOemFFCNormalizationTarget() – Sets the normalization
            //     target –
            //     All Lepton Configurations – LEP_RunOemFFC() – Executes the FFC normalization
            //     using previously specified normalization target value –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemFFCNormalizationTarget( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_FFC_NORMALIZATION_TARGET_T_PTR ffcTargetPtr ) LEP_RESULT LEP_SetOemFFCNormalizationTarget(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_FFC_NORMALIZATION_TARGET_T ffcTarget
            //     ) LEP_RESULT LEP_RunOemFFC typedef LEP_UINT16 LEP_OEM_FFC_NORMALIZATION_TARGET_T,
            //     *LEP_OEM_FFC_NORMALIZATION_TARGET_T_PTR;
            public ushort GetFFCNormalizationTargetChecked();
            //
            // Сводка:
            //     OEM FLIR Systems Part Number
            //     This function returns FLIR Systems’ Camera Part Number. The Camera Part Number
            //     is a 32-byte string identifier unique to a specific configuration of the Camera
            //     module.
            //     This command requires the Host to allocate the memory buffer before calling this
            //     function. The address to this memory block should be passed in as oemPartNumberPtr
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x1C
            //     SDK Data Length: Get 16 32-byte string
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemFlirPartNumber() – Updates oemPartNumberPtr
            //     with the Camera’s FLIR Systems Part Number. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemFlirPartNumber( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_PART_NUMBER_T_PTR oemPartNumberPtr ) /* Part Number: A (32 byte string)
            //     identifier unique to a ** specific configuration of module; essentially a module
            //     ** Configuration ID. */ typedef LEP_CHAR8 *LEP_OEM_PART_NUMBER_T, *LEP_OEM_PART_NUMBER_T_PTR;
            public PartNumber GetFlirPartNumber();
            //
            // Сводка:
            //     OEM FLIR Systems Part Number
            //     This function returns FLIR Systems’ Camera Part Number. The Camera Part Number
            //     is a 32-byte string identifier unique to a specific configuration of the Camera
            //     module.
            //     This command requires the Host to allocate the memory buffer before calling this
            //     function. The address to this memory block should be passed in as oemPartNumberPtr
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x1C
            //     SDK Data Length: Get 16 32-byte string
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemFlirPartNumber() – Updates oemPartNumberPtr
            //     with the Camera’s FLIR Systems Part Number. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemFlirPartNumber( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_PART_NUMBER_T_PTR oemPartNumberPtr ) /* Part Number: A (32 byte string)
            //     identifier unique to a ** specific configuration of module; essentially a module
            //     ** Configuration ID. */ typedef LEP_CHAR8 *LEP_OEM_PART_NUMBER_T, *LEP_OEM_PART_NUMBER_T_PTR;
            public PartNumber GetFlirPartNumberChecked();
            //
            // Сводка:
            //     OEM Frame Mean Intensity
            //     This function obtains the current frame mean intensity value within the video
            //     Region of Interest defined by SYS ROI (see 4.4.24). Note that this ROI (and the
            //     resulting mean) is not the same as that used by AGC Histogram Statistics.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 16383 – N/A – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x4C
            //     SDK Data Length: Get 1 size of a LEP_UINT16
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemFrameMean() – Gets the current frame mean
            //     intensity value within the SYS ROI –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemFrameMean( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_FRAME_AVERAGE_T_PTR
            //     frameAveragePtr ) typedef LEP_UINT16 LEP_OEM_FRAME_AVERAGE_T, *LEP_OEM_FRAME_AVERAGE_T_PTR;
            public ushort GetFrameMean();
            //
            // Сводка:
            //     OEM Frame Mean Intensity
            //     This function obtains the current frame mean intensity value within the video
            //     Region of Interest defined by SYS ROI (see 4.4.24). Note that this ROI (and the
            //     resulting mean) is not the same as that used by AGC Histogram Statistics.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 16383 – N/A – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x4C
            //     SDK Data Length: Get 1 size of a LEP_UINT16
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemFrameMean() – Gets the current frame mean
            //     intensity value within the SYS ROI –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemFrameMean( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_FRAME_AVERAGE_T_PTR
            //     frameAveragePtr ) typedef LEP_UINT16 LEP_OEM_FRAME_AVERAGE_T, *LEP_OEM_FRAME_AVERAGE_T_PTR;
            public ushort GetFrameMeanChecked();
            //
            // Сводка:
            //     OEM GPIO Mode Select
            //     This function gets and sets the GPIO pins mode.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_GPIO_MODE_GPIO – LEP_OEM_GPIO_MODE_VSYNC – LEP_OEM_GPIO_MODE_GPIO – N/A
            //     – 1 –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x54
            //     With Set 0x55
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemGpioMode() – Updates gpioModePtr with the
            //     Camera’s current GPIO pins mode. –
            //     All Lepton Configurations – LEP_SetOemGpioMode() – Updates the Camera’s GPIO
            //     pins mode with the contents of gpioMode. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemGpioMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_GPIO_MODE_E_PTR
            //     gpioModePtr ) LEP_RESULT LEP_SetOemGpioMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_GPIO_MODE_E gpioMode ) typedef enum LEP_OEM_GPIO_MODE_E_TAG { LEP_OEM_GPIO_MODE_GPIO
            //     = 0, LEP_OEM_GPIO_MODE_I2C_MASTER = 1, LEP_OEM_GPIO_MODE_SPI_MASTER_VLB_DATA
            //     = 2, LEP_OEM_GPIO_MODE_SPIO_MASTER_REG_DATA = 3, LEP_OEM_GPIO_MODE_SPI_SLAVE_VLB_DATA
            //     = 4, LEP_OEM_GPIO_MODE_VSYNC = 5, LEP_OEM_END_GPIO_MODE, }LEP_OEM_GPIO_MODE_E,
            //     *LEP_OEM_GPIO_MODE_E_PTR;
            public GpioMode GetGpioMode();
            //
            // Сводка:
            //     OEM GPIO Mode Select
            //     This function gets and sets the GPIO pins mode.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_GPIO_MODE_GPIO – LEP_OEM_GPIO_MODE_VSYNC – LEP_OEM_GPIO_MODE_GPIO – N/A
            //     – 1 –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x54
            //     With Set 0x55
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemGpioMode() – Updates gpioModePtr with the
            //     Camera’s current GPIO pins mode. –
            //     All Lepton Configurations – LEP_SetOemGpioMode() – Updates the Camera’s GPIO
            //     pins mode with the contents of gpioMode. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemGpioMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_GPIO_MODE_E_PTR
            //     gpioModePtr ) LEP_RESULT LEP_SetOemGpioMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_GPIO_MODE_E gpioMode ) typedef enum LEP_OEM_GPIO_MODE_E_TAG { LEP_OEM_GPIO_MODE_GPIO
            //     = 0, LEP_OEM_GPIO_MODE_I2C_MASTER = 1, LEP_OEM_GPIO_MODE_SPI_MASTER_VLB_DATA
            //     = 2, LEP_OEM_GPIO_MODE_SPIO_MASTER_REG_DATA = 3, LEP_OEM_GPIO_MODE_SPI_SLAVE_VLB_DATA
            //     = 4, LEP_OEM_GPIO_MODE_VSYNC = 5, LEP_OEM_END_GPIO_MODE, }LEP_OEM_GPIO_MODE_E,
            //     *LEP_OEM_GPIO_MODE_E_PTR;
            public GpioMode GetGpioModeChecked();
            //
            // Сводка:
            //     OEM GPIO VSync Phase Delay
            //     This function gets and sets the GPIO VSync phase delay. The Lepton Camera can
            //     issue a pulse on GPIO3 when there is an inter VSync. The output pulse may be
            //     issued in phase with the camera’s internal VSync, or it may be issued earlier
            //     or later. This command controls this phase relationship. The delays are in line
            //     periods, approximately 0.5 milliseconds per period. The phase delay is limited
            //     to +/- 3 line periods.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_VSYNC_DELAY_MINUS_3 – LEP_OEM_VSYNC_DELAY_PLUS_3 – LEP_OEM_VSYNC_DELAY_NONE
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x58
            //     With Set 0x59
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemGpioVsyncPhaseDelay() – Updates numHsyncLinesPtr
            //     with the Camera’s current GPIO VSync phase delay. –
            //     All Lepton Configurations – LEP_SetOemGpioVsyncPhaseDelay() – Updates the Camera’s
            //     GPIO VSync phase delay with the contents of numHsyncLines. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemGpioVsyncPhaseDelay( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_VSYNC_DELAY_E_PTR numHsyncLinesPtr ) LEP_RESULT LEP_SetOemGpioVsyncPhaseDelay(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_VSYNC_DELAY_E numHsyncLines )
            //     typedef enum LEP_OEM_VSYNC_DELAY_E_TAG { LEP_OEM_VSYNC_DELAY_MINUS_3 = -3, LEP_OEM_VSYNC_DELAY_MINUS_2
            //     = -2, LEP_OEM_VSYNC_DELAY_MINUS_1 = -1, LEP_OEM_VSYNC_DELAY_NONE = 0, LEP_OEM_VSYNC_DELAY_PLUS_1
            //     = 1, LEP_OEM_VSYNC_DELAY_PLUS_2 = 2, LEP_OEM_VSYNC_DELAY_PLUS_3 = 3, LEP_END_OEM_VSYNC_DELAY
            //     } LEP_OEM_VSYNC_DELAY_E, *LEP_OEM_VSYNC_DELAY_E_PTR;
            public VsyncDelay GetGpioVsyncPhaseDelay();
            //
            // Сводка:
            //     OEM GPIO VSync Phase Delay
            //     This function gets and sets the GPIO VSync phase delay. The Lepton Camera can
            //     issue a pulse on GPIO3 when there is an inter VSync. The output pulse may be
            //     issued in phase with the camera’s internal VSync, or it may be issued earlier
            //     or later. This command controls this phase relationship. The delays are in line
            //     periods, approximately 0.5 milliseconds per period. The phase delay is limited
            //     to +/- 3 line periods.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_VSYNC_DELAY_MINUS_3 – LEP_OEM_VSYNC_DELAY_PLUS_3 – LEP_OEM_VSYNC_DELAY_NONE
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x58
            //     With Set 0x59
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemGpioVsyncPhaseDelay() – Updates numHsyncLinesPtr
            //     with the Camera’s current GPIO VSync phase delay. –
            //     All Lepton Configurations – LEP_SetOemGpioVsyncPhaseDelay() – Updates the Camera’s
            //     GPIO VSync phase delay with the contents of numHsyncLines. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemGpioVsyncPhaseDelay( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_VSYNC_DELAY_E_PTR numHsyncLinesPtr ) LEP_RESULT LEP_SetOemGpioVsyncPhaseDelay(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_VSYNC_DELAY_E numHsyncLines )
            //     typedef enum LEP_OEM_VSYNC_DELAY_E_TAG { LEP_OEM_VSYNC_DELAY_MINUS_3 = -3, LEP_OEM_VSYNC_DELAY_MINUS_2
            //     = -2, LEP_OEM_VSYNC_DELAY_MINUS_1 = -1, LEP_OEM_VSYNC_DELAY_NONE = 0, LEP_OEM_VSYNC_DELAY_PLUS_1
            //     = 1, LEP_OEM_VSYNC_DELAY_PLUS_2 = 2, LEP_OEM_VSYNC_DELAY_PLUS_3 = 3, LEP_END_OEM_VSYNC_DELAY
            //     } LEP_OEM_VSYNC_DELAY_E, *LEP_OEM_VSYNC_DELAY_E_PTR;
            public VsyncDelay GetGpioVsyncPhaseDelayChecked();
            public ushort GetMaskRevision();
            public ushort GetMaskRevisionChecked();
            //
            // Сводка:
            //     OEM Pixel Noise Filter (SPNR) Control
            //     This function enables or disables the camera’s pixel noise filter.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x78
            //     With Set 0x79
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemPixelNoiseSettings() – Updates pixelNoiseSettingsPtr
            //     the Camera’s current pixel noise filter enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemPixelNoiseSettings() – Updates the Camera’s
            //     current pixel noise filter enable state with the contents of pixelNoiseSettings.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemPixelNoiseSettings( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_PIXEL_NOISE_SETTINGS_T_PTR pixelNoiseSettingsPtr ) LEP_RESULT LEP_SetOemPixelNoiseSettings(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_PIXEL_NOISE_SETTINGS_T pixelNoiseSettings
            //     ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG { LEP_OEM_DISABLE
            //     = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Pixel Noise Filter Control structure */ typedef struct LEP_OEM_PIXEL_NOISE_SETTINGS_T_TAG
            //     { LEP_OEM_STATE_E oemPixelNoiseEstimateEnable; }LEP_OEM_PIXEL_NOISE_SETTINGS_T,
            //     *LEP_OEM_PIXEL_NOISE_SETTINGS_T_PTR
            public PixelNoiseSettings GetPixelNoiseSettings();
            //
            // Сводка:
            //     OEM Pixel Noise Filter (SPNR) Control
            //     This function enables or disables the camera’s pixel noise filter.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x78
            //     With Set 0x79
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemPixelNoiseSettings() – Updates pixelNoiseSettingsPtr
            //     the Camera’s current pixel noise filter enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemPixelNoiseSettings() – Updates the Camera’s
            //     current pixel noise filter enable state with the contents of pixelNoiseSettings.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemPixelNoiseSettings( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_PIXEL_NOISE_SETTINGS_T_PTR pixelNoiseSettingsPtr ) LEP_RESULT LEP_SetOemPixelNoiseSettings(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_PIXEL_NOISE_SETTINGS_T pixelNoiseSettings
            //     ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG { LEP_OEM_DISABLE
            //     = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Pixel Noise Filter Control structure */ typedef struct LEP_OEM_PIXEL_NOISE_SETTINGS_T_TAG
            //     { LEP_OEM_STATE_E oemPixelNoiseEstimateEnable; }LEP_OEM_PIXEL_NOISE_SETTINGS_T,
            //     *LEP_OEM_PIXEL_NOISE_SETTINGS_T_PTR
            public PixelNoiseSettings GetPixelNoiseSettingsChecked();
            public PowerState GetPowerMode();
            public PowerState GetPowerModeChecked();
            //
            // Сводка:
            //     OEM Shutter Profile
            //     This function gets and sets the shutter profile.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_GPIO_MODE_GPIO – LEP_OEM_GPIO_MODE_VSYNC – LEP_OEM_GPIO_MODE_GPIO – N/A
            //     – 1 –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x64
            //     With Set 0x65
            //     SDK Data Length: Get 2 size of LEP_OEM_SHUTTER_PROFILE_OBJ_T Set 2 size of LEP_OEM_SHUTTER_PROFILE_OBJ_T
            //     data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemShutterProfileObj() – Updates ShutterProfileObjPtr
            //     with the Camera’s current shutter profile –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemShutterProfileObj() – Updates the Camera’s shutter
            //     profile with the contents of ShutterProfileObj. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemShutterProfileObj( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_SHUTTER_PROFILE_OBJ_T_PTR ShutterProfileObjPtr ) LEP_RESULT LEP_SetOemShutterProfileObj(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_SHUTTER_PROFILE_OBJ_T ShutterProfileObj
            //     ) /* Shutter Profile Object */ typedef struct LEP_OEM_SHUTTER_PROFILE_OBJ_T_TAG
            //     { LEP_UINT16 closePeriodInFrames; /* in frame counts x1 */ LEP_UINT16 openPeriodInFrames;
            //     /* in frame counts x1 */ }LEP_OEM_SHUTTER_PROFILE_OBJ_T, *LEP_OEM_SHUTTER_PROFILE_OBJ_T_PTR;
            public ShutterProfileObj GetShutterProfileObj();
            //
            // Сводка:
            //     OEM Shutter Profile
            //     This function gets and sets the shutter profile.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_GPIO_MODE_GPIO – LEP_OEM_GPIO_MODE_VSYNC – LEP_OEM_GPIO_MODE_GPIO – N/A
            //     – 1 –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x64
            //     With Set 0x65
            //     SDK Data Length: Get 2 size of LEP_OEM_SHUTTER_PROFILE_OBJ_T Set 2 size of LEP_OEM_SHUTTER_PROFILE_OBJ_T
            //     data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemShutterProfileObj() – Updates ShutterProfileObjPtr
            //     with the Camera’s current shutter profile –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemShutterProfileObj() – Updates the Camera’s shutter
            //     profile with the contents of ShutterProfileObj. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemShutterProfileObj( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_SHUTTER_PROFILE_OBJ_T_PTR ShutterProfileObjPtr ) LEP_RESULT LEP_SetOemShutterProfileObj(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_SHUTTER_PROFILE_OBJ_T ShutterProfileObj
            //     ) /* Shutter Profile Object */ typedef struct LEP_OEM_SHUTTER_PROFILE_OBJ_T_TAG
            //     { LEP_UINT16 closePeriodInFrames; /* in frame counts x1 */ LEP_UINT16 openPeriodInFrames;
            //     /* in frame counts x1 */ }LEP_OEM_SHUTTER_PROFILE_OBJ_T, *LEP_OEM_SHUTTER_PROFILE_OBJ_T_PTR;
            public ShutterProfileObj GetShutterProfileObjChecked();
            //
            // Сводка:
            //     OEM Camera Software Revision
            //     This function returns the Camera’s software revision for both software processors
            //     in the Camera. The Camera’s Software revision is composed of 3 fields: a major
            //     version, minor version, and a build number for each processor. Each of the 3
            //     fields is 8-bits.
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x20
            //     SDK Data Length: Get 4 size of LEP_OEM_SW_VERSION_T data type
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemSoftwareVersion() – Updates oemSoftwareVersionPtr
            //     with the Camera’s Software Revision. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemSoftwareVersion( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_SW_VERSION_T *oemSoftwareVersionPtr ) /* Software Version ID: A (24 bit
            //     depth) identifier for ** the software version stored in OTP. */ typedef struct
            //     LEP_OEM_SW_VERSION_TAG { LEP_UINT8 gpp_major; LEP_UINT8 gpp_minor; LEP_UINT8
            //     gpp_build; LEP_UINT8 dsp_major; LEP_UINT8 dsp_minor; LEP_UINT8 dsp_build; LEP_UINT16
            //     reserved; }LEP_OEM_SW_VERSION_T, *LEP_OEM_SW_VERSION_T_PTR;
            public SwVersion GetSoftwareVersion();
            //
            // Сводка:
            //     OEM Camera Software Revision
            //     This function returns the Camera’s software revision for both software processors
            //     in the Camera. The Camera’s Software revision is composed of 3 fields: a major
            //     version, minor version, and a build number for each processor. Each of the 3
            //     fields is 8-bits.
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x20
            //     SDK Data Length: Get 4 size of LEP_OEM_SW_VERSION_T data type
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemSoftwareVersion() – Updates oemSoftwareVersionPtr
            //     with the Camera’s Software Revision. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemSoftwareVersion( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_SW_VERSION_T *oemSoftwareVersionPtr ) /* Software Version ID: A (24 bit
            //     depth) identifier for ** the software version stored in OTP. */ typedef struct
            //     LEP_OEM_SW_VERSION_TAG { LEP_UINT8 gpp_major; LEP_UINT8 gpp_minor; LEP_UINT8
            //     gpp_build; LEP_UINT8 dsp_major; LEP_UINT8 dsp_minor; LEP_UINT8 dsp_build; LEP_UINT16
            //     reserved; }LEP_OEM_SW_VERSION_T, *LEP_OEM_SW_VERSION_T_PTR;
            public SwVersion GetSoftwareVersionChecked();
            //
            // Сводка:
            //     OEM Temporal Filter Control
            //     This function enables or disables the camera’s temporal filter.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x70
            //     With Set 0x71
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemTemporalFilterControl() – Updates TemporalFilterControlPtr
            //     the Camera’s current temporal filter enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemTemporalFilterControl() – Updates the Camera’s
            //     current temporal filter enable state with the contents of TemporalFilterControl.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemTemporalFilterControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_TEMPORAL_FILTER_CONTROL_T_PTR TemporalFilterControlPtr ) LEP_RESULT LEP_SetOemTemporalFilterControl(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_TEMPORAL_FILTER_CONTROL_T TemporalFilterControl
            //     ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG { LEP_OEM_DISABLE
            //     = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Temporal Filter Control structure */ typedef struct LEP_OEM_TEMPORAL_FILTER_CONTROL_T_TAG
            //     { LEP_OEM_STATE_E oemTemporalFilterEnable; }LEP_OEM_TEMPORAL_FILTER_CONTROL_T,
            //     *LEP_OEM_TEMPORAL_FILTER_CONTROL_T_PTR;
            public TemporalFilterControl GetTemporalFilterControl();
            //
            // Сводка:
            //     OEM Temporal Filter Control
            //     This function enables or disables the camera’s temporal filter.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x70
            //     With Set 0x71
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemTemporalFilterControl() – Updates TemporalFilterControlPtr
            //     the Camera’s current temporal filter enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemTemporalFilterControl() – Updates the Camera’s
            //     current temporal filter enable state with the contents of TemporalFilterControl.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemTemporalFilterControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_TEMPORAL_FILTER_CONTROL_T_PTR TemporalFilterControlPtr ) LEP_RESULT LEP_SetOemTemporalFilterControl(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_TEMPORAL_FILTER_CONTROL_T TemporalFilterControl
            //     ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG { LEP_OEM_DISABLE
            //     = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Temporal Filter Control structure */ typedef struct LEP_OEM_TEMPORAL_FILTER_CONTROL_T_TAG
            //     { LEP_OEM_STATE_E oemTemporalFilterEnable; }LEP_OEM_TEMPORAL_FILTER_CONTROL_T,
            //     *LEP_OEM_TEMPORAL_FILTER_CONTROL_T_PTR;
            public TemporalFilterControl GetTemporalFilterControlChecked();
            //
            // Сводка:
            //     OEM Thermal Shutdown Enable
            //     This function enables or disables the camera thermal shutdown intended to protect
            //     the camera from heating beyond operational temperature range.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x68
            //     With Set 0x69
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemThermalShutdownEnable() – Updates ThermalShutdownEnableStatePtr
            //     with the Camera’s current thermal shutdown enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemThermalShutdownEnable() – Updates the Camera’s
            //     current thermal shutdown enable state with the contents of ThermalShutdownEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemThermalShutdownEnable( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T_PTR ThermalShutdownEnableStatePtr ) LEP_RESULT
            //     LEP_SetOemThermalShutdownEnable( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T
            //     ThermalShutdownEnableState ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG
            //     { LEP_OEM_DISABLE = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Thermal Shutdown structure */ typedef struct LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T_TAG
            //     { LEP_OEM_STATE_E oemThermalShutdownEnable; }LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T,
            //     *LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T_PTR;
            public ThermalShutdownEnable GetThermalShutdownEnable();
            //
            // Сводка:
            //     OEM Thermal Shutdown Enable
            //     This function enables or disables the camera thermal shutdown intended to protect
            //     the camera from heating beyond operational temperature range.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x68
            //     With Set 0x69
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemThermalShutdownEnable() – Updates ThermalShutdownEnableStatePtr
            //     with the Camera’s current thermal shutdown enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemThermalShutdownEnable() – Updates the Camera’s
            //     current thermal shutdown enable state with the contents of ThermalShutdownEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemThermalShutdownEnable( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T_PTR ThermalShutdownEnableStatePtr ) LEP_RESULT
            //     LEP_SetOemThermalShutdownEnable( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T
            //     ThermalShutdownEnableState ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG
            //     { LEP_OEM_DISABLE = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Thermal Shutdown structure */ typedef struct LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T_TAG
            //     { LEP_OEM_STATE_E oemThermalShutdownEnable; }LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T,
            //     *LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T_PTR;
            public ThermalShutdownEnable GetThermalShutdownEnableChecked();
            //
            // Сводка:
            //     OEM User Defaults
            //     The camera supports the ability allow an OEM to save certain camera runtime states
            //     to OTP for persistent storage and automatic restore upon camera startup. The
            //     host can interrogate the camera to determine if the OEM default values were written
            //     to OTP or not using the LEP_GetOemUserDefaultsState API. The Host can also command
            //     the Camera to write the current camera values into OTP for automatic restore
            //     at camera startup using the LEP_RunOemUserDefaultsCopyToOtp API. The VPROG voltage
            //     must be set in order to write the user defaults to OTP successfully.
            //
            // Примечания:
            //     Coordinate – Minimum Value – Maximum Value – Value – Units – Scale factor –
            //     row
            //     – 0 – 119 – N/A – N/A – 1 –
            //     col
            //     – 0 – 159 – N/A – N/A – 1 –
            //     SDK Module ID: VID 0x800
            //     SDK Command ID: Base With Get With Run 0x5E
            //     SDK Data Length: Get 2 Run 0 size a run command argument
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemUserDefaultsState() – Updates userParamsStatePtr
            //     with the Camera’s current OEM OTP user defaults written sate –
            //     Lepton 2.5, 3.0, 3.5 – LEP_RunOemUserDefaultsCopyToOtp() – Executes writing the
            //     OEM user defaults to OTP –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemUserDefaultsState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_USER_PARAMS_STATE_E_PTR userParamsStatePtr) LEP_RESULT LEP_RunOemUserDefaultsCopyToOtp(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr) /* OEM User Defaults State */ typedef enum LEP_OEM_USER_PARAMS_STATE_E_TAG
            //     { LEP_OEM_USER_PARAMS_STATE_NOT_WRITTEN = 0, LEP_OEM_USER_PARAMS_STATE_WRITTEN,
            //     LEP_OEM_END_USER_PARAMS_STATE, }LEP_OEM_USER_PARAMS_STATE_E, *LEP_OEM_USER_PARAMS_STATE_E_PTR;
            public UserParamsState GetUserDefaultsState();
            //
            // Сводка:
            //     OEM User Defaults
            //     The camera supports the ability allow an OEM to save certain camera runtime states
            //     to OTP for persistent storage and automatic restore upon camera startup. The
            //     host can interrogate the camera to determine if the OEM default values were written
            //     to OTP or not using the LEP_GetOemUserDefaultsState API. The Host can also command
            //     the Camera to write the current camera values into OTP for automatic restore
            //     at camera startup using the LEP_RunOemUserDefaultsCopyToOtp API. The VPROG voltage
            //     must be set in order to write the user defaults to OTP successfully.
            //
            // Примечания:
            //     Coordinate – Minimum Value – Maximum Value – Value – Units – Scale factor –
            //     row
            //     – 0 – 119 – N/A – N/A – 1 –
            //     col
            //     – 0 – 159 – N/A – N/A – 1 –
            //     SDK Module ID: VID 0x800
            //     SDK Command ID: Base With Get With Run 0x5E
            //     SDK Data Length: Get 2 Run 0 size a run command argument
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemUserDefaultsState() – Updates userParamsStatePtr
            //     with the Camera’s current OEM OTP user defaults written sate –
            //     Lepton 2.5, 3.0, 3.5 – LEP_RunOemUserDefaultsCopyToOtp() – Executes writing the
            //     OEM user defaults to OTP –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemUserDefaultsState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_USER_PARAMS_STATE_E_PTR userParamsStatePtr) LEP_RESULT LEP_RunOemUserDefaultsCopyToOtp(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr) /* OEM User Defaults State */ typedef enum LEP_OEM_USER_PARAMS_STATE_E_TAG
            //     { LEP_OEM_USER_PARAMS_STATE_NOT_WRITTEN = 0, LEP_OEM_USER_PARAMS_STATE_WRITTEN,
            //     LEP_OEM_END_USER_PARAMS_STATE, }LEP_OEM_USER_PARAMS_STATE_E, *LEP_OEM_USER_PARAMS_STATE_E_PTR;
            public UserParamsState GetUserDefaultsStateChecked();
            public VideoGammaEnable GetVideoGammaEnable();
            public VideoGammaEnable GetVideoGammaEnableChecked();
            public VideoOutputChannel GetVideoOutputChannel();
            public VideoOutputChannel GetVideoOutputChannelChecked();
            //
            // Сводка:
            //     OEM Video Output Enable
            //     This function enables or disables the video output independent of output channel.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VIDEO_OUTPUT_DISABLE – LEP_VIDEO_OUTPUT_ENABLE – LEP_VIDEO_OUTPUT_ENABLE
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemVideoOutputEnable() – Updates oemVideoOutputEnablePtr
            //     with the Camera’s current video output enable. –
            //     All Lepton Configurations – LEP_SetOemVideoOutputEnable() – Updates the Camera’s
            //     current video output enable with the contents of oemVideoOutputEnable. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemVideoOutputEnable(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     oemVideoOutputEnablePtr) LEP_RESULT LEP_SetOemVideoOutputEnable(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, oemVideoOutputEnable) /* Video Output Enable Enum */ typedef enum
            //     LEP_OEM_VIDEO_OUTPUT_ENABLE_TAG { LEP_VIDEO_OUTPUT_DISABLE = 0, LEP_VIDEO_OUTPUT_ENABLE,
            //     LEP_END_VIDEO_OUTPUT_ENABLE }LEP_OEM_VIDEO_OUTPUT_ENABLE_E, *LEP_OEM_VIDEO_OUTPUT_ENABLE_E_PTR;
            public VideoOutputEnable GetVideoOutputEnable();
            //
            // Сводка:
            //     OEM Video Output Enable
            //     This function enables or disables the video output independent of output channel.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VIDEO_OUTPUT_DISABLE – LEP_VIDEO_OUTPUT_ENABLE – LEP_VIDEO_OUTPUT_ENABLE
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemVideoOutputEnable() – Updates oemVideoOutputEnablePtr
            //     with the Camera’s current video output enable. –
            //     All Lepton Configurations – LEP_SetOemVideoOutputEnable() – Updates the Camera’s
            //     current video output enable with the contents of oemVideoOutputEnable. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemVideoOutputEnable(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     oemVideoOutputEnablePtr) LEP_RESULT LEP_SetOemVideoOutputEnable(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, oemVideoOutputEnable) /* Video Output Enable Enum */ typedef enum
            //     LEP_OEM_VIDEO_OUTPUT_ENABLE_TAG { LEP_VIDEO_OUTPUT_DISABLE = 0, LEP_VIDEO_OUTPUT_ENABLE,
            //     LEP_END_VIDEO_OUTPUT_ENABLE }LEP_OEM_VIDEO_OUTPUT_ENABLE_E, *LEP_OEM_VIDEO_OUTPUT_ENABLE_E_PTR;
            public VideoOutputEnable GetVideoOutputEnableChecked();
            //
            // Сводка:
            //     OEM Video Output Format Select
            //     This function provides the method to specify or retrieve the current video output
            //     format. In the current revision, only RGB888 and RAW14 are valid formats.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VIDEO_OUTPUT_FORMAT_RAW8 – LEP_VIDEO_OUTPUT_FORMAT_RAW8_6 – LEP_VIDEO_OUTPUT_FORMAT_RAW14
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x28
            //     With Set 0x29
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemVideoOutputFormat() – Updates oemVideoOutputFormatPtr
            //     with the Camera’s current video output format selection. –
            //     All Lepton Configurations – LEP_SetOemVideoOutputFormat() – Updates the Camera’s
            //     current video output format with the contents of oemVideoOutputFormat. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemVideoOutputFormat(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     oemVideoOutputFormatPtr) LEP_RESULT LEP_SetOemVideoOutputFormat(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, oemVideoOutputFormat) /* Video Output Format Selection */ typedef
            //     enum LEP_OEM_VIDEO_OUTPUT_FORMAT_TAG { // To be supported in later release //
            //     To be supported in later release // To be supported in later release // SUPPORTED
            //     in this release // To be supported in later release // To be supported in later
            //     release // To be supported in later release // SUPPORTED in this release // To
            //     be supported in later release // To be supported in later release // To be supported
            //     in later release // To be supported in later release // To be supported in later
            //     release // To be supported in later release // To be supported in later release
            //     LEP_END_VIDEO_OUTPUT_FORMAT }LEP_OEM_VIDEO_OUTPUT_FORMAT_E, *LEP_OEM_VIDEO_OUTPUT_FORMAT_E_PTR;
            public VideoOutputFormat GetVideoOutputFormat();
            //
            // Сводка:
            //     OEM Video Output Format Select
            //     This function provides the method to specify or retrieve the current video output
            //     format. In the current revision, only RGB888 and RAW14 are valid formats.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VIDEO_OUTPUT_FORMAT_RAW8 – LEP_VIDEO_OUTPUT_FORMAT_RAW8_6 – LEP_VIDEO_OUTPUT_FORMAT_RAW14
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x28
            //     With Set 0x29
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemVideoOutputFormat() – Updates oemVideoOutputFormatPtr
            //     with the Camera’s current video output format selection. –
            //     All Lepton Configurations – LEP_SetOemVideoOutputFormat() – Updates the Camera’s
            //     current video output format with the contents of oemVideoOutputFormat. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemVideoOutputFormat(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     oemVideoOutputFormatPtr) LEP_RESULT LEP_SetOemVideoOutputFormat(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, oemVideoOutputFormat) /* Video Output Format Selection */ typedef
            //     enum LEP_OEM_VIDEO_OUTPUT_FORMAT_TAG { // To be supported in later release //
            //     To be supported in later release // To be supported in later release // SUPPORTED
            //     in this release // To be supported in later release // To be supported in later
            //     release // To be supported in later release // SUPPORTED in this release // To
            //     be supported in later release // To be supported in later release // To be supported
            //     in later release // To be supported in later release // To be supported in later
            //     release // To be supported in later release // To be supported in later release
            //     LEP_END_VIDEO_OUTPUT_FORMAT }LEP_OEM_VIDEO_OUTPUT_FORMAT_E, *LEP_OEM_VIDEO_OUTPUT_FORMAT_E_PTR;
            public VideoOutputFormat GetVideoOutputFormatChecked();
            //
            // Сводка:
            //     OEM Video Output Source Select
            //     This function specifies or retrieves the video output source. The output source
            //     allows selecting between processed video data, unprocessed video data, and a
            //     variety of ramp patterns.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VIDEO_OUTPUT_SOURCE_RAW – LEP_VIDEO_OUTPUT_SOURCE_FRAME_4 – LEP_VIDEO_OUTPUT_SOURCE_COOKED
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x2C
            //     With Set 0x2D
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemVideoOutputSource() – Updates oemVideoOutputSourcePtr
            //     with the Camera’s current video output format selection. –
            //     All Lepton Configurations – LEP_SetOemVideoOutputSource() – Updates the Camera’s
            //     current video output format with the contents of oemVideoOutputSource. –
            //     C SDK Interface:
            //     oemVideoOutputSourcePtr) oemVideoOutputSource) /* Video Output Source Selection
            //     */ typedef enum LEP_OEM_VIDEO_OUTPUT_SOURCE_TAG { /* Before video processing.
            //     */ /* Post video processing - NORMAL MODE */ /* Software Ramp pattern - increase
            //     in X, Y */ /* Software Constant value pattern */ /* Software Ramp pattern - increase
            //     in X only */ /* Software Ramp pattern - increase in Y only */ /* Software Ramp
            //     pattern - uses custom settings */ /* Additions to support frame averaging, freeze
            //     frame, and data buffers */ // Average, Capture frame // Freeze-Frame Buffer /*
            //     RESERVED BUFFERS */ // Reserved DATA Buffer // Reserved DATA Buffer // Reserved
            //     DATA Buffer // Reserved DATA Buffer // Reserved DATA Buffer LEP_END_VIDEO_OUTPUT_SOURCE
            //     }LEP_OEM_VIDEO_OUTPUT_SOURCE_E, *LEP_OEM_VIDEO_OUTPUT_SOURCE_E_PTR;
            public VideoOutputSource GetVideoOutputSource();
            //
            // Сводка:
            //     OEM Video Output Source Select
            //     This function specifies or retrieves the video output source. The output source
            //     allows selecting between processed video data, unprocessed video data, and a
            //     variety of ramp patterns.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VIDEO_OUTPUT_SOURCE_RAW – LEP_VIDEO_OUTPUT_SOURCE_FRAME_4 – LEP_VIDEO_OUTPUT_SOURCE_COOKED
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x2C
            //     With Set 0x2D
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemVideoOutputSource() – Updates oemVideoOutputSourcePtr
            //     with the Camera’s current video output format selection. –
            //     All Lepton Configurations – LEP_SetOemVideoOutputSource() – Updates the Camera’s
            //     current video output format with the contents of oemVideoOutputSource. –
            //     C SDK Interface:
            //     oemVideoOutputSourcePtr) oemVideoOutputSource) /* Video Output Source Selection
            //     */ typedef enum LEP_OEM_VIDEO_OUTPUT_SOURCE_TAG { /* Before video processing.
            //     */ /* Post video processing - NORMAL MODE */ /* Software Ramp pattern - increase
            //     in X, Y */ /* Software Constant value pattern */ /* Software Ramp pattern - increase
            //     in X only */ /* Software Ramp pattern - increase in Y only */ /* Software Ramp
            //     pattern - uses custom settings */ /* Additions to support frame averaging, freeze
            //     frame, and data buffers */ // Average, Capture frame // Freeze-Frame Buffer /*
            //     RESERVED BUFFERS */ // Reserved DATA Buffer // Reserved DATA Buffer // Reserved
            //     DATA Buffer // Reserved DATA Buffer // Reserved DATA Buffer LEP_END_VIDEO_OUTPUT_SOURCE
            //     }LEP_OEM_VIDEO_OUTPUT_SOURCE_E, *LEP_OEM_VIDEO_OUTPUT_SOURCE_E_PTR;
            public VideoOutputSource GetVideoOutputSourceChecked();
            public ushort GetVideoOutputSourceConstant();
            public ushort GetVideoOutputSourceConstantChecked();
            public void RunBit();
            public void RunBitChecked();
            public void RunFFC();
            public void RunFFCChecked();
            //
            // Сводка:
            //     OEM Run FFC Normalization Frames – Aggregate Command
            //     This is an aggregate command that executes the FFC Normalization using a parameter
            //     to specify the FFC target value explicitly. This command does use the number
            //     of frames to average as specified by the SYS Number of frames to average (see
            //     4.4.21).
            //     Executing this command causes the camera to execute the FFC Normalization. The
            //     FFC target value is specified by parameter to this function. This command does
            //     not use the current target value in the Camera.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 16383 – 8192 – N/A – N/A –
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunOemFFCNormalization() – Executes the FFC normalization
            //     using the FFC target value specified by parameter to this function. Aggregate
            //     command. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunOemFFCNormalization( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_FFC_NORMALIZATION_TARGET_T ffcTarget ) typedef LEP_UINT16 LEP_OEM_FFC_NORMALIZATION_TARGET_T,
            //     *LEP_OEM_FFC_NORMALIZATION_TARGET_T_PTR;
            public void RunFFCNormalization(ushort arg);
            //
            // Сводка:
            //     OEM Run FFC Normalization Frames – Aggregate Command
            //     This is an aggregate command that executes the FFC Normalization using a parameter
            //     to specify the FFC target value explicitly. This command does use the number
            //     of frames to average as specified by the SYS Number of frames to average (see
            //     4.4.21).
            //     Executing this command causes the camera to execute the FFC Normalization. The
            //     FFC target value is specified by parameter to this function. This command does
            //     not use the current target value in the Camera.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 16383 – 8192 – N/A – N/A –
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunOemFFCNormalization() – Executes the FFC normalization
            //     using the FFC target value specified by parameter to this function. Aggregate
            //     command. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunOemFFCNormalization( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_FFC_NORMALIZATION_TARGET_T ffcTarget ) typedef LEP_UINT16 LEP_OEM_FFC_NORMALIZATION_TARGET_T,
            //     *LEP_OEM_FFC_NORMALIZATION_TARGET_T_PTR;
            public void RunFFCNormalizationChecked(ushort arg);
            public void RunLowPowerMode1();
            public void RunLowPowerMode1Checked();
            public void RunLowPowerMode2();
            public void RunLowPowerMode2Checked();
            //
            // Сводка:
            //     OEM Power Down
            //     This function sends the Power Down command to the camera to effectively shut
            //     the Camera off. The camera will respond with LEP_OK if command received correctly
            //     and then place the Camera into a power down or OFF mode after a small delay.
            //     Power Down is identical to the Camera s mode; both place the Camera into the
            //     OFF state.
            //     To turn the Camera back ON using software, the Host must perform the following
            //     sequence:
            //
            // Примечания:
            //     Let the ASIC hold the DATA line (SDA) low
            //     Issue a single clock pulse. This Is required for the ASIC to de-assert the DATA
            //     line.
            //     Call LEP_RunOemPowerOn() (see 4.6.2). This function will write a ZERO (0x0000)
            //     to the Camera Device ID to turn the Camera ON.
            //     This will bring the Camera out of Power Down.
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Run 0x02
            //     SDK Data Length: Run 0 size a run command argument
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunOemPowerDown() – Issues a Camera Power Down
            //     command to the Camera –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunOemPowerDown(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunPowerDown();
            //
            // Сводка:
            //     OEM Power Down
            //     This function sends the Power Down command to the camera to effectively shut
            //     the Camera off. The camera will respond with LEP_OK if command received correctly
            //     and then place the Camera into a power down or OFF mode after a small delay.
            //     Power Down is identical to the Camera s mode; both place the Camera into the
            //     OFF state.
            //     To turn the Camera back ON using software, the Host must perform the following
            //     sequence:
            //
            // Примечания:
            //     Let the ASIC hold the DATA line (SDA) low
            //     Issue a single clock pulse. This Is required for the ASIC to de-assert the DATA
            //     line.
            //     Call LEP_RunOemPowerOn() (see 4.6.2). This function will write a ZERO (0x0000)
            //     to the Camera Device ID to turn the Camera ON.
            //     This will bring the Camera out of Power Down.
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Run 0x02
            //     SDK Data Length: Run 0 size a run command argument
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunOemPowerDown() – Issues a Camera Power Down
            //     command to the Camera –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunOemPowerDown(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunPowerDownChecked();
            //
            // Сводка:
            //     OEM Power On
            //     This function sends the Power On command to the camera to turn the Camera ON
            //     once the camera was shutdown using the LEP_RunOemPowerDown() command (see 4.6.3).
            //     The power ON command is executed by the SDK (not the camera) by writing a ZERO
            //     (0x0000) to the Camera I2C Device ID (see 2.1.3). This will turn the camera ON
            //     if the power down and reset pins are NOT asserted.
            //     Note that this command is not fully supported. It works the first time, after
            //     that, a power cycle is required.
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base N/A
            //     SDK Data Length: Run N/A size a run command argument
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunOemPowerOn() – Issues a Camera Power Down
            //     command to the Camera –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunOemPowerOn(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunPowerOn();
            //
            // Сводка:
            //     OEM Power On
            //     This function sends the Power On command to the camera to turn the Camera ON
            //     once the camera was shutdown using the LEP_RunOemPowerDown() command (see 4.6.3).
            //     The power ON command is executed by the SDK (not the camera) by writing a ZERO
            //     (0x0000) to the Camera I2C Device ID (see 2.1.3). This will turn the camera ON
            //     if the power down and reset pins are NOT asserted.
            //     Note that this command is not fully supported. It works the first time, after
            //     that, a power cycle is required.
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base N/A
            //     SDK Data Length: Run N/A size a run command argument
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunOemPowerOn() – Issues a Camera Power Down
            //     command to the Camera –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunOemPowerOn(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunPowerOnChecked();
            //
            // Сводка:
            //     OEM Run Camera Re-Boot
            //     This function commands the Camera to re-boot. The Camera is first shutdown, and
            //     then restarts automatically.
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Run 0x42
            //     SDK Data Length: Run 0 size a run command argument
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunOemReboot() – Issues a run Camera Re-Boot
            //     command to the Camera. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunOemReboot(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunReboot();
            //
            // Сводка:
            //     OEM Run Camera Re-Boot
            //     This function commands the Camera to re-boot. The Camera is first shutdown, and
            //     then restarts automatically.
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Run 0x42
            //     SDK Data Length: Run 0 size a run command argument
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunOemReboot() – Issues a run Camera Re-Boot
            //     command to the Camera. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunOemReboot(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunRebootChecked();
            public void RunStandby();
            public void RunStandbyChecked();
            public void RunUserDefaultsCopyToOtp();
            public void RunUserDefaultsCopyToOtpChecked();
            //
            // Сводка:
            //     OEM Restore User Defaults
            //     This function will restore the OEM user defaults from OTP if OTP was previously
            //     written with these defaults. If user defaults were not previously written, an
            //     error code is returned.
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Run 0x62
            //     SDK Data Length: Run 0 size a run command argument
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_RunOemUserDefaultsRestore() – Restore the OEM user
            //     defaults from OTP if OTP was previously written with these defaults –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunOemUserDefaultsRestore(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunUserDefaultsRestore();
            //
            // Сводка:
            //     OEM Restore User Defaults
            //     This function will restore the OEM user defaults from OTP if OTP was previously
            //     written with these defaults. If user defaults were not previously written, an
            //     error code is returned.
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Run 0x62
            //     SDK Data Length: Run 0 size a run command argument
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_RunOemUserDefaultsRestore() – Restore the OEM user
            //     defaults from OTP if OTP was previously written with these defaults –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunOemUserDefaultsRestore(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunUserDefaultsRestoreChecked();
            //
            // Сводка:
            //     OEM Bad Pixel Replacement Control
            //     This function enables or disables the camera’s bad pixel replacement control.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x6C
            //     With Set 0x6D
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemBadPixelReplaceControl() – Updates BadPixelReplaceControlPtrwith
            //     the Camera’s current bad pixel replacement control enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemBadPixelReplaceControl() – Updates the Camera’s
            //     current bad pixel replacement control enable state with the contents of BadPixelReplaceControl.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemBadPixelReplaceControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T_PTR BadPixelReplaceControlPtr ) LEP_RESULT
            //     LEP_SetOemBadPixelReplaceControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T
            //     BadPixelReplaceControl ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG
            //     { LEP_OEM_DISABLE = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Bad Pixel Replacement Control structure */ typedef struct LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T_TAG
            //     { LEP_OEM_STATE_E oemBadPixelReplaceEnable; }LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T,
            //     *LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T_PTR;
            public void SetBadPixelReplaceControl(BadPixelReplaceControl source);
            //
            // Сводка:
            //     OEM Bad Pixel Replacement Control
            //     This function enables or disables the camera’s bad pixel replacement control.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x6C
            //     With Set 0x6D
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemBadPixelReplaceControl() – Updates BadPixelReplaceControlPtrwith
            //     the Camera’s current bad pixel replacement control enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemBadPixelReplaceControl() – Updates the Camera’s
            //     current bad pixel replacement control enable state with the contents of BadPixelReplaceControl.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemBadPixelReplaceControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T_PTR BadPixelReplaceControlPtr ) LEP_RESULT
            //     LEP_SetOemBadPixelReplaceControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T
            //     BadPixelReplaceControl ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG
            //     { LEP_OEM_DISABLE = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Bad Pixel Replacement Control structure */ typedef struct LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T_TAG
            //     { LEP_OEM_STATE_E oemBadPixelReplaceEnable; }LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T,
            //     *LEP_OEM_BAD_PIXEL_REPLACE_CONTROL_T_PTR;
            public void SetBadPixelReplaceControlChecked(BadPixelReplaceControl source);
            //
            // Сводка:
            //     OEM Column Noise Filter (SCNR) Control
            //     This function enables or disables the camera’s column noise filter.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x74
            //     With Set 0x75
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemColumnNoiseEstimateControl() – Updates ColumnNoiseEstimateControlPtr
            //     the Camera’s current column noise filter enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemColumnNoiseEstimateControl() – Updates the Camera’s
            //     current column noise filter enable state with the contents of ColumnNoiseEstimateControl.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemColumnNoiseEstimateControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T_PTR ColumnNoiseEstimateControlPtr ) LEP_RESULT
            //     LEP_SetOemColumnNoiseEstimateControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T ColumnNoiseEstimateControl ) /* Enable
            //     State Enum */ typedef enum LEP_OEM_STATE_E_TAG { LEP_OEM_DISABLE = 0, LEP_OEM_ENABLE,
            //     LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR; /* Column Noise Filter
            //     Control structure */ typedef struct LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T_TAG
            //     { LEP_OEM_STATE_E oemColumnNoiseEstimateEnable; }LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T,
            //     *LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T_PTR;
            public void SetColumnNoiseEstimateControl(ColumnNoiseEstimateControl source);
            //
            // Сводка:
            //     OEM Column Noise Filter (SCNR) Control
            //     This function enables or disables the camera’s column noise filter.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x74
            //     With Set 0x75
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemColumnNoiseEstimateControl() – Updates ColumnNoiseEstimateControlPtr
            //     the Camera’s current column noise filter enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemColumnNoiseEstimateControl() – Updates the Camera’s
            //     current column noise filter enable state with the contents of ColumnNoiseEstimateControl.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemColumnNoiseEstimateControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T_PTR ColumnNoiseEstimateControlPtr ) LEP_RESULT
            //     LEP_SetOemColumnNoiseEstimateControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T ColumnNoiseEstimateControl ) /* Enable
            //     State Enum */ typedef enum LEP_OEM_STATE_E_TAG { LEP_OEM_DISABLE = 0, LEP_OEM_ENABLE,
            //     LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR; /* Column Noise Filter
            //     Control structure */ typedef struct LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T_TAG
            //     { LEP_OEM_STATE_E oemColumnNoiseEstimateEnable; }LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T,
            //     *LEP_OEM_COLUMN_NOISE_ESTIMATE_CONTROL_T_PTR;
            public void SetColumnNoiseEstimateControlChecked(ColumnNoiseEstimateControl source);
            //
            // Сводка:
            //     OEM FFC Normalization Target
            //     The first two of these commands Get and Set the Flat-Field Correction (FFC) Normalization
            //     Target used by the third command to execute a Flat-Field Correction (FFC). The
            //     target value is factory set and should not be changed under normal circumstances.
            //     The Run command executes an FFC using currently active values for the FFC normalization
            //     target and number of frames to average (see 4.4.21). This command executes synchronously.
            //     Poll the OEM Status to determine when this command completes (see 4.6.13).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 16383 – 8192 – N/A – N/A –
            //     SDK Module ID: SYS 0x0800
            //     SDK Command ID: Base With Get 0x44 With Set With Run 0x46
            //     SDK Data Length: Get 1 size of a LEP_UINT16 Set 1 size of a Run 0 size of a Run
            //     command
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemFFCNormalizationTarget() – Gets the normalization
            //     target –
            //     All Lepton Configurations – LEP_SetOemFFCNormalizationTarget() – Sets the normalization
            //     target –
            //     All Lepton Configurations – LEP_RunOemFFC() – Executes the FFC normalization
            //     using previously specified normalization target value –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemFFCNormalizationTarget( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_FFC_NORMALIZATION_TARGET_T_PTR ffcTargetPtr ) LEP_RESULT LEP_SetOemFFCNormalizationTarget(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_FFC_NORMALIZATION_TARGET_T ffcTarget
            //     ) LEP_RESULT LEP_RunOemFFC typedef LEP_UINT16 LEP_OEM_FFC_NORMALIZATION_TARGET_T,
            //     *LEP_OEM_FFC_NORMALIZATION_TARGET_T_PTR;
            public void SetFFCNormalizationTarget(ushort source);
            //
            // Сводка:
            //     OEM FFC Normalization Target
            //     The first two of these commands Get and Set the Flat-Field Correction (FFC) Normalization
            //     Target used by the third command to execute a Flat-Field Correction (FFC). The
            //     target value is factory set and should not be changed under normal circumstances.
            //     The Run command executes an FFC using currently active values for the FFC normalization
            //     target and number of frames to average (see 4.4.21). This command executes synchronously.
            //     Poll the OEM Status to determine when this command completes (see 4.6.13).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 16383 – 8192 – N/A – N/A –
            //     SDK Module ID: SYS 0x0800
            //     SDK Command ID: Base With Get 0x44 With Set With Run 0x46
            //     SDK Data Length: Get 1 size of a LEP_UINT16 Set 1 size of a Run 0 size of a Run
            //     command
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemFFCNormalizationTarget() – Gets the normalization
            //     target –
            //     All Lepton Configurations – LEP_SetOemFFCNormalizationTarget() – Sets the normalization
            //     target –
            //     All Lepton Configurations – LEP_RunOemFFC() – Executes the FFC normalization
            //     using previously specified normalization target value –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemFFCNormalizationTarget( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_FFC_NORMALIZATION_TARGET_T_PTR ffcTargetPtr ) LEP_RESULT LEP_SetOemFFCNormalizationTarget(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_FFC_NORMALIZATION_TARGET_T ffcTarget
            //     ) LEP_RESULT LEP_RunOemFFC typedef LEP_UINT16 LEP_OEM_FFC_NORMALIZATION_TARGET_T,
            //     *LEP_OEM_FFC_NORMALIZATION_TARGET_T_PTR;
            public void SetFFCNormalizationTargetChecked(ushort source);
            //
            // Сводка:
            //     OEM GPIO Mode Select
            //     This function gets and sets the GPIO pins mode.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_GPIO_MODE_GPIO – LEP_OEM_GPIO_MODE_VSYNC – LEP_OEM_GPIO_MODE_GPIO – N/A
            //     – 1 –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x54
            //     With Set 0x55
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemGpioMode() – Updates gpioModePtr with the
            //     Camera’s current GPIO pins mode. –
            //     All Lepton Configurations – LEP_SetOemGpioMode() – Updates the Camera’s GPIO
            //     pins mode with the contents of gpioMode. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemGpioMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_GPIO_MODE_E_PTR
            //     gpioModePtr ) LEP_RESULT LEP_SetOemGpioMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_GPIO_MODE_E gpioMode ) typedef enum LEP_OEM_GPIO_MODE_E_TAG { LEP_OEM_GPIO_MODE_GPIO
            //     = 0, LEP_OEM_GPIO_MODE_I2C_MASTER = 1, LEP_OEM_GPIO_MODE_SPI_MASTER_VLB_DATA
            //     = 2, LEP_OEM_GPIO_MODE_SPIO_MASTER_REG_DATA = 3, LEP_OEM_GPIO_MODE_SPI_SLAVE_VLB_DATA
            //     = 4, LEP_OEM_GPIO_MODE_VSYNC = 5, LEP_OEM_END_GPIO_MODE, }LEP_OEM_GPIO_MODE_E,
            //     *LEP_OEM_GPIO_MODE_E_PTR;
            public void SetGpioMode(GpioMode source);
            //
            // Сводка:
            //     OEM GPIO Mode Select
            //     This function gets and sets the GPIO pins mode.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_GPIO_MODE_GPIO – LEP_OEM_GPIO_MODE_VSYNC – LEP_OEM_GPIO_MODE_GPIO – N/A
            //     – 1 –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x54
            //     With Set 0x55
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemGpioMode() – Updates gpioModePtr with the
            //     Camera’s current GPIO pins mode. –
            //     All Lepton Configurations – LEP_SetOemGpioMode() – Updates the Camera’s GPIO
            //     pins mode with the contents of gpioMode. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemGpioMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_GPIO_MODE_E_PTR
            //     gpioModePtr ) LEP_RESULT LEP_SetOemGpioMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_GPIO_MODE_E gpioMode ) typedef enum LEP_OEM_GPIO_MODE_E_TAG { LEP_OEM_GPIO_MODE_GPIO
            //     = 0, LEP_OEM_GPIO_MODE_I2C_MASTER = 1, LEP_OEM_GPIO_MODE_SPI_MASTER_VLB_DATA
            //     = 2, LEP_OEM_GPIO_MODE_SPIO_MASTER_REG_DATA = 3, LEP_OEM_GPIO_MODE_SPI_SLAVE_VLB_DATA
            //     = 4, LEP_OEM_GPIO_MODE_VSYNC = 5, LEP_OEM_END_GPIO_MODE, }LEP_OEM_GPIO_MODE_E,
            //     *LEP_OEM_GPIO_MODE_E_PTR;
            public void SetGpioModeChecked(GpioMode source);
            //
            // Сводка:
            //     OEM GPIO VSync Phase Delay
            //     This function gets and sets the GPIO VSync phase delay. The Lepton Camera can
            //     issue a pulse on GPIO3 when there is an inter VSync. The output pulse may be
            //     issued in phase with the camera’s internal VSync, or it may be issued earlier
            //     or later. This command controls this phase relationship. The delays are in line
            //     periods, approximately 0.5 milliseconds per period. The phase delay is limited
            //     to +/- 3 line periods.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_VSYNC_DELAY_MINUS_3 – LEP_OEM_VSYNC_DELAY_PLUS_3 – LEP_OEM_VSYNC_DELAY_NONE
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x58
            //     With Set 0x59
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemGpioVsyncPhaseDelay() – Updates numHsyncLinesPtr
            //     with the Camera’s current GPIO VSync phase delay. –
            //     All Lepton Configurations – LEP_SetOemGpioVsyncPhaseDelay() – Updates the Camera’s
            //     GPIO VSync phase delay with the contents of numHsyncLines. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemGpioVsyncPhaseDelay( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_VSYNC_DELAY_E_PTR numHsyncLinesPtr ) LEP_RESULT LEP_SetOemGpioVsyncPhaseDelay(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_VSYNC_DELAY_E numHsyncLines )
            //     typedef enum LEP_OEM_VSYNC_DELAY_E_TAG { LEP_OEM_VSYNC_DELAY_MINUS_3 = -3, LEP_OEM_VSYNC_DELAY_MINUS_2
            //     = -2, LEP_OEM_VSYNC_DELAY_MINUS_1 = -1, LEP_OEM_VSYNC_DELAY_NONE = 0, LEP_OEM_VSYNC_DELAY_PLUS_1
            //     = 1, LEP_OEM_VSYNC_DELAY_PLUS_2 = 2, LEP_OEM_VSYNC_DELAY_PLUS_3 = 3, LEP_END_OEM_VSYNC_DELAY
            //     } LEP_OEM_VSYNC_DELAY_E, *LEP_OEM_VSYNC_DELAY_E_PTR;
            public void SetGpioVsyncPhaseDelay(VsyncDelay source);
            //
            // Сводка:
            //     OEM GPIO VSync Phase Delay
            //     This function gets and sets the GPIO VSync phase delay. The Lepton Camera can
            //     issue a pulse on GPIO3 when there is an inter VSync. The output pulse may be
            //     issued in phase with the camera’s internal VSync, or it may be issued earlier
            //     or later. This command controls this phase relationship. The delays are in line
            //     periods, approximately 0.5 milliseconds per period. The phase delay is limited
            //     to +/- 3 line periods.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_VSYNC_DELAY_MINUS_3 – LEP_OEM_VSYNC_DELAY_PLUS_3 – LEP_OEM_VSYNC_DELAY_NONE
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x58
            //     With Set 0x59
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemGpioVsyncPhaseDelay() – Updates numHsyncLinesPtr
            //     with the Camera’s current GPIO VSync phase delay. –
            //     All Lepton Configurations – LEP_SetOemGpioVsyncPhaseDelay() – Updates the Camera’s
            //     GPIO VSync phase delay with the contents of numHsyncLines. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemGpioVsyncPhaseDelay( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_VSYNC_DELAY_E_PTR numHsyncLinesPtr ) LEP_RESULT LEP_SetOemGpioVsyncPhaseDelay(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_VSYNC_DELAY_E numHsyncLines )
            //     typedef enum LEP_OEM_VSYNC_DELAY_E_TAG { LEP_OEM_VSYNC_DELAY_MINUS_3 = -3, LEP_OEM_VSYNC_DELAY_MINUS_2
            //     = -2, LEP_OEM_VSYNC_DELAY_MINUS_1 = -1, LEP_OEM_VSYNC_DELAY_NONE = 0, LEP_OEM_VSYNC_DELAY_PLUS_1
            //     = 1, LEP_OEM_VSYNC_DELAY_PLUS_2 = 2, LEP_OEM_VSYNC_DELAY_PLUS_3 = 3, LEP_END_OEM_VSYNC_DELAY
            //     } LEP_OEM_VSYNC_DELAY_E, *LEP_OEM_VSYNC_DELAY_E_PTR;
            public void SetGpioVsyncPhaseDelayChecked(VsyncDelay source);
            //
            // Сводка:
            //     OEM Pixel Noise Filter (SPNR) Control
            //     This function enables or disables the camera’s pixel noise filter.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x78
            //     With Set 0x79
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemPixelNoiseSettings() – Updates pixelNoiseSettingsPtr
            //     the Camera’s current pixel noise filter enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemPixelNoiseSettings() – Updates the Camera’s
            //     current pixel noise filter enable state with the contents of pixelNoiseSettings.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemPixelNoiseSettings( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_PIXEL_NOISE_SETTINGS_T_PTR pixelNoiseSettingsPtr ) LEP_RESULT LEP_SetOemPixelNoiseSettings(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_PIXEL_NOISE_SETTINGS_T pixelNoiseSettings
            //     ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG { LEP_OEM_DISABLE
            //     = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Pixel Noise Filter Control structure */ typedef struct LEP_OEM_PIXEL_NOISE_SETTINGS_T_TAG
            //     { LEP_OEM_STATE_E oemPixelNoiseEstimateEnable; }LEP_OEM_PIXEL_NOISE_SETTINGS_T,
            //     *LEP_OEM_PIXEL_NOISE_SETTINGS_T_PTR
            public void SetPixelNoiseSettings(PixelNoiseSettings source);
            //
            // Сводка:
            //     OEM Pixel Noise Filter (SPNR) Control
            //     This function enables or disables the camera’s pixel noise filter.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x78
            //     With Set 0x79
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemPixelNoiseSettings() – Updates pixelNoiseSettingsPtr
            //     the Camera’s current pixel noise filter enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemPixelNoiseSettings() – Updates the Camera’s
            //     current pixel noise filter enable state with the contents of pixelNoiseSettings.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemPixelNoiseSettings( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_PIXEL_NOISE_SETTINGS_T_PTR pixelNoiseSettingsPtr ) LEP_RESULT LEP_SetOemPixelNoiseSettings(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_PIXEL_NOISE_SETTINGS_T pixelNoiseSettings
            //     ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG { LEP_OEM_DISABLE
            //     = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Pixel Noise Filter Control structure */ typedef struct LEP_OEM_PIXEL_NOISE_SETTINGS_T_TAG
            //     { LEP_OEM_STATE_E oemPixelNoiseEstimateEnable; }LEP_OEM_PIXEL_NOISE_SETTINGS_T,
            //     *LEP_OEM_PIXEL_NOISE_SETTINGS_T_PTR
            public void SetPixelNoiseSettingsChecked(PixelNoiseSettings source);
            public void SetPowerMode(PowerState source);
            public void SetPowerModeChecked(PowerState source);
            //
            // Сводка:
            //     OEM Shutter Profile
            //     This function gets and sets the shutter profile.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_GPIO_MODE_GPIO – LEP_OEM_GPIO_MODE_VSYNC – LEP_OEM_GPIO_MODE_GPIO – N/A
            //     – 1 –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x64
            //     With Set 0x65
            //     SDK Data Length: Get 2 size of LEP_OEM_SHUTTER_PROFILE_OBJ_T Set 2 size of LEP_OEM_SHUTTER_PROFILE_OBJ_T
            //     data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemShutterProfileObj() – Updates ShutterProfileObjPtr
            //     with the Camera’s current shutter profile –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemShutterProfileObj() – Updates the Camera’s shutter
            //     profile with the contents of ShutterProfileObj. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemShutterProfileObj( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_SHUTTER_PROFILE_OBJ_T_PTR ShutterProfileObjPtr ) LEP_RESULT LEP_SetOemShutterProfileObj(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_SHUTTER_PROFILE_OBJ_T ShutterProfileObj
            //     ) /* Shutter Profile Object */ typedef struct LEP_OEM_SHUTTER_PROFILE_OBJ_T_TAG
            //     { LEP_UINT16 closePeriodInFrames; /* in frame counts x1 */ LEP_UINT16 openPeriodInFrames;
            //     /* in frame counts x1 */ }LEP_OEM_SHUTTER_PROFILE_OBJ_T, *LEP_OEM_SHUTTER_PROFILE_OBJ_T_PTR;
            public void SetShutterProfileObj(ShutterProfileObj source);
            //
            // Сводка:
            //     OEM Shutter Profile
            //     This function gets and sets the shutter profile.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_GPIO_MODE_GPIO – LEP_OEM_GPIO_MODE_VSYNC – LEP_OEM_GPIO_MODE_GPIO – N/A
            //     – 1 –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x64
            //     With Set 0x65
            //     SDK Data Length: Get 2 size of LEP_OEM_SHUTTER_PROFILE_OBJ_T Set 2 size of LEP_OEM_SHUTTER_PROFILE_OBJ_T
            //     data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemShutterProfileObj() – Updates ShutterProfileObjPtr
            //     with the Camera’s current shutter profile –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemShutterProfileObj() – Updates the Camera’s shutter
            //     profile with the contents of ShutterProfileObj. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemShutterProfileObj( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_SHUTTER_PROFILE_OBJ_T_PTR ShutterProfileObjPtr ) LEP_RESULT LEP_SetOemShutterProfileObj(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_SHUTTER_PROFILE_OBJ_T ShutterProfileObj
            //     ) /* Shutter Profile Object */ typedef struct LEP_OEM_SHUTTER_PROFILE_OBJ_T_TAG
            //     { LEP_UINT16 closePeriodInFrames; /* in frame counts x1 */ LEP_UINT16 openPeriodInFrames;
            //     /* in frame counts x1 */ }LEP_OEM_SHUTTER_PROFILE_OBJ_T, *LEP_OEM_SHUTTER_PROFILE_OBJ_T_PTR;
            public void SetShutterProfileObjChecked(ShutterProfileObj source);
            //
            // Сводка:
            //     OEM Temporal Filter Control
            //     This function enables or disables the camera’s temporal filter.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x70
            //     With Set 0x71
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemTemporalFilterControl() – Updates TemporalFilterControlPtr
            //     the Camera’s current temporal filter enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemTemporalFilterControl() – Updates the Camera’s
            //     current temporal filter enable state with the contents of TemporalFilterControl.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemTemporalFilterControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_TEMPORAL_FILTER_CONTROL_T_PTR TemporalFilterControlPtr ) LEP_RESULT LEP_SetOemTemporalFilterControl(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_TEMPORAL_FILTER_CONTROL_T TemporalFilterControl
            //     ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG { LEP_OEM_DISABLE
            //     = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Temporal Filter Control structure */ typedef struct LEP_OEM_TEMPORAL_FILTER_CONTROL_T_TAG
            //     { LEP_OEM_STATE_E oemTemporalFilterEnable; }LEP_OEM_TEMPORAL_FILTER_CONTROL_T,
            //     *LEP_OEM_TEMPORAL_FILTER_CONTROL_T_PTR;
            public void SetTemporalFilterControl(TemporalFilterControl source);
            //
            // Сводка:
            //     OEM Temporal Filter Control
            //     This function enables or disables the camera’s temporal filter.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x70
            //     With Set 0x71
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemTemporalFilterControl() – Updates TemporalFilterControlPtr
            //     the Camera’s current temporal filter enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemTemporalFilterControl() – Updates the Camera’s
            //     current temporal filter enable state with the contents of TemporalFilterControl.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemTemporalFilterControl( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_TEMPORAL_FILTER_CONTROL_T_PTR TemporalFilterControlPtr ) LEP_RESULT LEP_SetOemTemporalFilterControl(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_TEMPORAL_FILTER_CONTROL_T TemporalFilterControl
            //     ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG { LEP_OEM_DISABLE
            //     = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Temporal Filter Control structure */ typedef struct LEP_OEM_TEMPORAL_FILTER_CONTROL_T_TAG
            //     { LEP_OEM_STATE_E oemTemporalFilterEnable; }LEP_OEM_TEMPORAL_FILTER_CONTROL_T,
            //     *LEP_OEM_TEMPORAL_FILTER_CONTROL_T_PTR;
            public void SetTemporalFilterControlChecked(TemporalFilterControl source);
            //
            // Сводка:
            //     OEM Thermal Shutdown Enable
            //     This function enables or disables the camera thermal shutdown intended to protect
            //     the camera from heating beyond operational temperature range.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x68
            //     With Set 0x69
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemThermalShutdownEnable() – Updates ThermalShutdownEnableStatePtr
            //     with the Camera’s current thermal shutdown enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemThermalShutdownEnable() – Updates the Camera’s
            //     current thermal shutdown enable state with the contents of ThermalShutdownEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemThermalShutdownEnable( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T_PTR ThermalShutdownEnableStatePtr ) LEP_RESULT
            //     LEP_SetOemThermalShutdownEnable( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T
            //     ThermalShutdownEnableState ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG
            //     { LEP_OEM_DISABLE = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Thermal Shutdown structure */ typedef struct LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T_TAG
            //     { LEP_OEM_STATE_E oemThermalShutdownEnable; }LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T,
            //     *LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T_PTR;
            public void SetThermalShutdownEnable(ThermalShutdownEnable source);
            //
            // Сводка:
            //     OEM Thermal Shutdown Enable
            //     This function enables or disables the camera thermal shutdown intended to protect
            //     the camera from heating beyond operational temperature range.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_OEM_DISABLE – LEP_OEM_ENABLE – LEP_OEM_ENABLE – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x68
            //     With Set 0x69
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetOemThermalShutdownEnable() – Updates ThermalShutdownEnableStatePtr
            //     with the Camera’s current thermal shutdown enable state. –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetOemThermalShutdownEnable() – Updates the Camera’s
            //     current thermal shutdown enable state with the contents of ThermalShutdownEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemThermalShutdownEnable( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T_PTR ThermalShutdownEnableStatePtr ) LEP_RESULT
            //     LEP_SetOemThermalShutdownEnable( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T
            //     ThermalShutdownEnableState ) /* Enable State Enum */ typedef enum LEP_OEM_STATE_E_TAG
            //     { LEP_OEM_DISABLE = 0, LEP_OEM_ENABLE, LEP_OEM_END_STATE }LEP_OEM_STATE_E,*LEP_OEM_STATE_E_PTR;
            //     /* Thermal Shutdown structure */ typedef struct LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T_TAG
            //     { LEP_OEM_STATE_E oemThermalShutdownEnable; }LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T,
            //     *LEP_OEM_THERMAL_SHUTDOWN_ENABLE_T_PTR;
            public void SetThermalShutdownEnableChecked(ThermalShutdownEnable source);
            public void SetVideoGammaEnable(VideoGammaEnable source);
            public void SetVideoGammaEnableChecked(VideoGammaEnable source);
            public void SetVideoOutputChannel(VideoOutputChannel source);
            public void SetVideoOutputChannelChecked(VideoOutputChannel source);
            //
            // Сводка:
            //     OEM Video Output Enable
            //     This function enables or disables the video output independent of output channel.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VIDEO_OUTPUT_DISABLE – LEP_VIDEO_OUTPUT_ENABLE – LEP_VIDEO_OUTPUT_ENABLE
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemVideoOutputEnable() – Updates oemVideoOutputEnablePtr
            //     with the Camera’s current video output enable. –
            //     All Lepton Configurations – LEP_SetOemVideoOutputEnable() – Updates the Camera’s
            //     current video output enable with the contents of oemVideoOutputEnable. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemVideoOutputEnable(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     oemVideoOutputEnablePtr) LEP_RESULT LEP_SetOemVideoOutputEnable(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, oemVideoOutputEnable) /* Video Output Enable Enum */ typedef enum
            //     LEP_OEM_VIDEO_OUTPUT_ENABLE_TAG { LEP_VIDEO_OUTPUT_DISABLE = 0, LEP_VIDEO_OUTPUT_ENABLE,
            //     LEP_END_VIDEO_OUTPUT_ENABLE }LEP_OEM_VIDEO_OUTPUT_ENABLE_E, *LEP_OEM_VIDEO_OUTPUT_ENABLE_E_PTR;
            public void SetVideoOutputEnable(VideoOutputEnable source);
            //
            // Сводка:
            //     OEM Video Output Enable
            //     This function enables or disables the video output independent of output channel.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VIDEO_OUTPUT_DISABLE – LEP_VIDEO_OUTPUT_ENABLE – LEP_VIDEO_OUTPUT_ENABLE
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemVideoOutputEnable() – Updates oemVideoOutputEnablePtr
            //     with the Camera’s current video output enable. –
            //     All Lepton Configurations – LEP_SetOemVideoOutputEnable() – Updates the Camera’s
            //     current video output enable with the contents of oemVideoOutputEnable. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemVideoOutputEnable(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     oemVideoOutputEnablePtr) LEP_RESULT LEP_SetOemVideoOutputEnable(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, oemVideoOutputEnable) /* Video Output Enable Enum */ typedef enum
            //     LEP_OEM_VIDEO_OUTPUT_ENABLE_TAG { LEP_VIDEO_OUTPUT_DISABLE = 0, LEP_VIDEO_OUTPUT_ENABLE,
            //     LEP_END_VIDEO_OUTPUT_ENABLE }LEP_OEM_VIDEO_OUTPUT_ENABLE_E, *LEP_OEM_VIDEO_OUTPUT_ENABLE_E_PTR;
            public void SetVideoOutputEnableChecked(VideoOutputEnable source);
            //
            // Сводка:
            //     OEM Video Output Format Select
            //     This function provides the method to specify or retrieve the current video output
            //     format. In the current revision, only RGB888 and RAW14 are valid formats.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VIDEO_OUTPUT_FORMAT_RAW8 – LEP_VIDEO_OUTPUT_FORMAT_RAW8_6 – LEP_VIDEO_OUTPUT_FORMAT_RAW14
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x28
            //     With Set 0x29
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemVideoOutputFormat() – Updates oemVideoOutputFormatPtr
            //     with the Camera’s current video output format selection. –
            //     All Lepton Configurations – LEP_SetOemVideoOutputFormat() – Updates the Camera’s
            //     current video output format with the contents of oemVideoOutputFormat. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemVideoOutputFormat(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     oemVideoOutputFormatPtr) LEP_RESULT LEP_SetOemVideoOutputFormat(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, oemVideoOutputFormat) /* Video Output Format Selection */ typedef
            //     enum LEP_OEM_VIDEO_OUTPUT_FORMAT_TAG { // To be supported in later release //
            //     To be supported in later release // To be supported in later release // SUPPORTED
            //     in this release // To be supported in later release // To be supported in later
            //     release // To be supported in later release // SUPPORTED in this release // To
            //     be supported in later release // To be supported in later release // To be supported
            //     in later release // To be supported in later release // To be supported in later
            //     release // To be supported in later release // To be supported in later release
            //     LEP_END_VIDEO_OUTPUT_FORMAT }LEP_OEM_VIDEO_OUTPUT_FORMAT_E, *LEP_OEM_VIDEO_OUTPUT_FORMAT_E_PTR;
            public void SetVideoOutputFormat(VideoOutputFormat source);
            //
            // Сводка:
            //     OEM Video Output Format Select
            //     This function provides the method to specify or retrieve the current video output
            //     format. In the current revision, only RGB888 and RAW14 are valid formats.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VIDEO_OUTPUT_FORMAT_RAW8 – LEP_VIDEO_OUTPUT_FORMAT_RAW8_6 – LEP_VIDEO_OUTPUT_FORMAT_RAW14
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x28
            //     With Set 0x29
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemVideoOutputFormat() – Updates oemVideoOutputFormatPtr
            //     with the Camera’s current video output format selection. –
            //     All Lepton Configurations – LEP_SetOemVideoOutputFormat() – Updates the Camera’s
            //     current video output format with the contents of oemVideoOutputFormat. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetOemVideoOutputFormat(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     oemVideoOutputFormatPtr) LEP_RESULT LEP_SetOemVideoOutputFormat(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, oemVideoOutputFormat) /* Video Output Format Selection */ typedef
            //     enum LEP_OEM_VIDEO_OUTPUT_FORMAT_TAG { // To be supported in later release //
            //     To be supported in later release // To be supported in later release // SUPPORTED
            //     in this release // To be supported in later release // To be supported in later
            //     release // To be supported in later release // SUPPORTED in this release // To
            //     be supported in later release // To be supported in later release // To be supported
            //     in later release // To be supported in later release // To be supported in later
            //     release // To be supported in later release // To be supported in later release
            //     LEP_END_VIDEO_OUTPUT_FORMAT }LEP_OEM_VIDEO_OUTPUT_FORMAT_E, *LEP_OEM_VIDEO_OUTPUT_FORMAT_E_PTR;
            public void SetVideoOutputFormatChecked(VideoOutputFormat source);
            //
            // Сводка:
            //     OEM Video Output Source Select
            //     This function specifies or retrieves the video output source. The output source
            //     allows selecting between processed video data, unprocessed video data, and a
            //     variety of ramp patterns.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VIDEO_OUTPUT_SOURCE_RAW – LEP_VIDEO_OUTPUT_SOURCE_FRAME_4 – LEP_VIDEO_OUTPUT_SOURCE_COOKED
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x2C
            //     With Set 0x2D
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemVideoOutputSource() – Updates oemVideoOutputSourcePtr
            //     with the Camera’s current video output format selection. –
            //     All Lepton Configurations – LEP_SetOemVideoOutputSource() – Updates the Camera’s
            //     current video output format with the contents of oemVideoOutputSource. –
            //     C SDK Interface:
            //     oemVideoOutputSourcePtr) oemVideoOutputSource) /* Video Output Source Selection
            //     */ typedef enum LEP_OEM_VIDEO_OUTPUT_SOURCE_TAG { /* Before video processing.
            //     */ /* Post video processing - NORMAL MODE */ /* Software Ramp pattern - increase
            //     in X, Y */ /* Software Constant value pattern */ /* Software Ramp pattern - increase
            //     in X only */ /* Software Ramp pattern - increase in Y only */ /* Software Ramp
            //     pattern - uses custom settings */ /* Additions to support frame averaging, freeze
            //     frame, and data buffers */ // Average, Capture frame // Freeze-Frame Buffer /*
            //     RESERVED BUFFERS */ // Reserved DATA Buffer // Reserved DATA Buffer // Reserved
            //     DATA Buffer // Reserved DATA Buffer // Reserved DATA Buffer LEP_END_VIDEO_OUTPUT_SOURCE
            //     }LEP_OEM_VIDEO_OUTPUT_SOURCE_E, *LEP_OEM_VIDEO_OUTPUT_SOURCE_E_PTR;
            public void SetVideoOutputSource(VideoOutputSource source);
            //
            // Сводка:
            //     OEM Video Output Source Select
            //     This function specifies or retrieves the video output source. The output source
            //     allows selecting between processed video data, unprocessed video data, and a
            //     variety of ramp patterns.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VIDEO_OUTPUT_SOURCE_RAW – LEP_VIDEO_OUTPUT_SOURCE_FRAME_4 – LEP_VIDEO_OUTPUT_SOURCE_COOKED
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0800
            //     SDK Command ID: Base With Get 0x2C
            //     With Set 0x2D
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetOemVideoOutputSource() – Updates oemVideoOutputSourcePtr
            //     with the Camera’s current video output format selection. –
            //     All Lepton Configurations – LEP_SetOemVideoOutputSource() – Updates the Camera’s
            //     current video output format with the contents of oemVideoOutputSource. –
            //     C SDK Interface:
            //     oemVideoOutputSourcePtr) oemVideoOutputSource) /* Video Output Source Selection
            //     */ typedef enum LEP_OEM_VIDEO_OUTPUT_SOURCE_TAG { /* Before video processing.
            //     */ /* Post video processing - NORMAL MODE */ /* Software Ramp pattern - increase
            //     in X, Y */ /* Software Constant value pattern */ /* Software Ramp pattern - increase
            //     in X only */ /* Software Ramp pattern - increase in Y only */ /* Software Ramp
            //     pattern - uses custom settings */ /* Additions to support frame averaging, freeze
            //     frame, and data buffers */ // Average, Capture frame // Freeze-Frame Buffer /*
            //     RESERVED BUFFERS */ // Reserved DATA Buffer // Reserved DATA Buffer // Reserved
            //     DATA Buffer // Reserved DATA Buffer // Reserved DATA Buffer LEP_END_VIDEO_OUTPUT_SOURCE
            //     }LEP_OEM_VIDEO_OUTPUT_SOURCE_E, *LEP_OEM_VIDEO_OUTPUT_SOURCE_E_PTR;
            public void SetVideoOutputSourceChecked(VideoOutputSource source);
            public void SetVideoOutputSourceConstant(ushort source);
            public void SetVideoOutputSourceConstantChecked(ushort source);

            public enum UserParamsState
            {
                NOT_WRITTEN = 0,
                WRITTEN = 1
            }
            public enum GpioMode
            {
                GPIO = 0,
                I2C_MASTER = 1,
                SPI_MASTER_VLB_DATA = 2,
                SPIO_MASTER_REG_DATA = 3,
                SPI_SLAVE_VLB_DATA = 4,
                VSYNC = 5
            }
            public enum VsyncDelay
            {
                MINUS_3 = -3,
                MINUS_2 = -2,
                MINUS_1 = -1,
                NONE = 0,
                PLUS_1 = 1,
                PLUS_2 = 2,
                PLUS_3 = 3
            }
            public enum State
            {
                DISABLE = 0,
                ENABLE = 1
            }
            public enum Status
            {
                STATUS_OTP_WRITE_ERROR = -2,
                STATUS_ERROR = -1,
                STATUS_READY = 0,
                STATUS_BUSY = 1,
                FRAME_AVERAGE_COLLECTING_FRAMES = 2
            }
            public enum PowerState
            {
                POWER_MODE_NORMAL = 0,
                POWER_MODE_LOW_POWER_1 = 1,
                POWER_MODE_LOW_POWER_2 = 2
            }
            public enum VideoGammaEnable
            {
                DISABLE = 0,
                ENABLE = 1
            }
            public enum VideoOutputChannel
            {
                MIPI = 0,
                VOSPI = 1
            }
            public enum VideoOutputSource
            {
                RAW = 0,
                COOKED = 1,
                RAMP = 2,
                CONSTANT = 3,
                RAMP_H = 4,
                RAMP_V = 5,
                RAMP_CUSTOM = 6,
                FRAME_CAPTURE = 7,
                FRAME_FREEZE = 8,
                FRAME_0 = 9,
                FRAME_1 = 10,
                FRAME_2 = 11,
                FRAME_3 = 12,
                FRAME_4 = 13
            }
            public enum VideoOutputFormat
            {
                RAW8 = 0,
                RAW10 = 1,
                RAW12 = 2,
                RGB888 = 3,
                RGB666 = 4,
                RGB565 = 5,
                YUV422_8BIT = 6,
                RAW14 = 7,
                YUV422_10BIT = 8,
                USER_DEFINED = 9,
                RAW8_2 = 10,
                RAW8_3 = 11,
                RAW8_4 = 12,
                RAW8_5 = 13,
                RAW8_6 = 14
            }
            public enum VideoOutputEnable
            {
                DISABLE = 0,
                ENABLE = 1
            }
            public enum MemBuffer
            {
                MEM_OTP_ODAC = 0,
                MEM_OTP_GAIN = 1,
                MEM_OTP_OFFSET_0 = 2,
                MEM_OTP_OFFSET_1 = 3,
                MEM_OTP_FFC = 4,
                MEM_OTP_LG0 = 5,
                MEM_OTP_LG1 = 6,
                MEM_OTP_LG2 = 7,
                MEM_OTP_TFPA_LUT = 8,
                MEM_OTP_TAUX_LUT = 9,
                MEM_OTP_BAD_PIXEL_LIST = 10,
                MEM_SRAM_ODAC = 11,
                MEM_SRAM_BAD_PIXEL_LIST = 12,
                MEM_SHARED_BUFFER_0 = 13,
                MEM_SHARED_BUFFER_1 = 14,
                MEM_SHARED_BUFFER_2 = 15,
                MEM_SHARED_BUFFER_3 = 16,
                MEM_SHARED_BUFFER_4 = 17
            }

            public class PixelNoiseSettings
            {
                public State oemPixelNoiseEstimateEnable;

                public PixelNoiseSettings(State oemPixelNoiseEstimateEnable);

                public override string ToString();
            }
            public class PartNumber
            {
                public sbyte[] value;

                public PartNumber(sbyte[] value);

                public override string ToString();
            }
            public class SwVersion
            {
                public byte gpp_major;
                public byte gpp_minor;
                public byte gpp_build;
                public byte dsp_major;
                public byte dsp_minor;
                public byte dsp_build;
                public ushort reserved;

                public SwVersion(byte gpp_major, byte gpp_minor, byte gpp_build, byte dsp_major, byte dsp_minor, byte dsp_build, ushort reserved);

                public override string ToString();
            }
            public class ShutterProfileObj
            {
                public ushort closePeriodInFrames;
                public ushort openPeriodInFrames;

                public ShutterProfileObj(ushort closePeriodInFrames, ushort openPeriodInFrames);

                public override string ToString();
            }
            public class BadPixelReplaceControl
            {
                public State oemBadPixelReplaceEnable;

                public BadPixelReplaceControl(State oemBadPixelReplaceEnable);

                public override string ToString();
            }
            public class TemporalFilterControl
            {
                public State oemTemporalFilterEnable;

                public TemporalFilterControl(State oemTemporalFilterEnable);

                public override string ToString();
            }
            public class ColumnNoiseEstimateControl
            {
                public State oemColumnNoiseEstimateEnable;

                public ColumnNoiseEstimateControl(State oemColumnNoiseEstimateEnable);

                public override string ToString();
            }
            public class ThermalShutdownEnable
            {
                public State oemThermalShutdownEnable;

                public ThermalShutdownEnable(State oemThermalShutdownEnable);

                public override string ToString();
            }
        }
        //
        // Сводка:
        //     This module provides interfaces to the cameraâ€™s radiometry features. Note that
        //     the Lepton 1.5, 1.6 and 2.0 releases includes radiometry features that support
        //     temperature stable output, but the radiometric releases includes additional calibrations
        //     and radiometric features.
        public class Rad
        {
            public Rad(UVC port);

            public short GetArbitraryOffset();
            public short GetArbitraryOffsetChecked();
            public ArbitraryOffsetMode GetArbitraryOffsetMode();
            public ArbitraryOffsetMode GetArbitraryOffsetModeChecked();
            public ArbitraryOffsetParams GetArbitraryOffsetParams();
            public ArbitraryOffsetParams GetArbitraryOffsetParamsChecked();
            public ushort GetCnfScaleFactor();
            public ushort GetCnfScaleFactorChecked();
            public int GetDebugFlux();
            public int GetDebugFluxChecked();
            public ushort GetDebugTemp();
            public ushort GetDebugTempChecked();
            //
            // Сводка:
            //     RAD Radiometry Control Enable
            //     This function enables or disables the Camera Radiometry Control (temperature
            //     stable output), or returns the state of Control.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     radEnableState – LEP_RAD_DISABLE – LEP_RAD_ENABLE – LEP_RAD_DISABLE – LEP_RAD_ENABLE
            //     – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x10
            //     With Set 0x11
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine value
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadEnableState() – Updates radEnableStatePtr
            //     with current state of the radiometry control. –
            //     All Lepton Configurations – LEP_SetRadEnableState() – Updates the Camera’s with
            //     current state of the radiometry control with the contents of radEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadEnableState( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ENABLE_E_PTR
            //     radEnableStatePtr ) LEP_RESULT LEP_SetRadEnableState( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RAD_ENABLE_E radEnableState ) /* Radiometry Enable state */
            //     typedef enum LEP_RAD_ENABLE_E_TAG { LEP_RAD_DISABLE = 0, LEP_RAD_ENABLE, LEP_END_RAD_ENABLE
            //     }LEP_RAD_ENABLE_E, *LEP_RAD_ENABLE_E_PTR;
            public Enable GetEnableState();
            //
            // Сводка:
            //     RAD Radiometry Control Enable
            //     This function enables or disables the Camera Radiometry Control (temperature
            //     stable output), or returns the state of Control.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     radEnableState – LEP_RAD_DISABLE – LEP_RAD_ENABLE – LEP_RAD_DISABLE – LEP_RAD_ENABLE
            //     – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x10
            //     With Set 0x11
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine value
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadEnableState() – Updates radEnableStatePtr
            //     with current state of the radiometry control. –
            //     All Lepton Configurations – LEP_SetRadEnableState() – Updates the Camera’s with
            //     current state of the radiometry control with the contents of radEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadEnableState( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ENABLE_E_PTR
            //     radEnableStatePtr ) LEP_RESULT LEP_SetRadEnableState( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RAD_ENABLE_E radEnableState ) /* Radiometry Enable state */
            //     typedef enum LEP_RAD_ENABLE_E_TAG { LEP_RAD_DISABLE = 0, LEP_RAD_ENABLE, LEP_END_RAD_ENABLE
            //     }LEP_RAD_ENABLE_E, *LEP_RAD_ENABLE_E_PTR;
            public Enable GetEnableStateChecked();
            public Rbfo GetExternalRBFOHighGain();
            public Rbfo GetExternalRBFOHighGainChecked();
            //
            // Сводка:
            //     RAD Low Gain RBFO External Parameters
            //     These functions either get or set the radiometry low gain RBFO External parameters.
            //     The RBFO parameters define the equation for conversion between flux and temperature.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     R – 10000 – 1000000 – 64155 – Calibrated per camera – N/A – 1 –
            //     B – 1200000 – 1700000 – 1428000 – Calibrated per camera – N/A – 1000 –
            //     F – 500 – 3000 – 1000 – Calibrated per camera – N/A – 1000 –
            //     O – -16384000 – 16383000 – 728000 – Calibrated per camera – N/A – 1000 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0xD8
            //     With Set 0xD9
            //     SDK Data Length: Get 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Set 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadExternalRBFOLowGain() – Updates radRBFOPtr with the
            //     Camera’s current RBFO External parameters. –
            //     Lepton 2.5, 3.5 – LEP_SetRadExternalRBFOLowGain() – Updates the Camera’s RBFO
            //     External parameters with the contents of radRBFOPtr. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadExternalRBFOLowGain ( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RBFO_T_PTR radRBFOPtr ) LEP_RESULT LEP_SetRadExternalRBFOLowGain ( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RBFO_T_PTR radRBFOPtr ) /* RBFO */ typedef struct LEP_RBFO_T_TAG
            //     { // value is not scaled // value is scaled by X << n LEP_UINT32 RBFO_F; LEP_INT32
            //     RBFO_O; }LEP_RBFO_T, *LEP_RBFO_T_PTR;
            public Rbfo GetExternalRBFOLowGain();
            //
            // Сводка:
            //     RAD Low Gain RBFO External Parameters
            //     These functions either get or set the radiometry low gain RBFO External parameters.
            //     The RBFO parameters define the equation for conversion between flux and temperature.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     R – 10000 – 1000000 – 64155 – Calibrated per camera – N/A – 1 –
            //     B – 1200000 – 1700000 – 1428000 – Calibrated per camera – N/A – 1000 –
            //     F – 500 – 3000 – 1000 – Calibrated per camera – N/A – 1000 –
            //     O – -16384000 – 16383000 – 728000 – Calibrated per camera – N/A – 1000 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0xD8
            //     With Set 0xD9
            //     SDK Data Length: Get 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Set 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadExternalRBFOLowGain() – Updates radRBFOPtr with the
            //     Camera’s current RBFO External parameters. –
            //     Lepton 2.5, 3.5 – LEP_SetRadExternalRBFOLowGain() – Updates the Camera’s RBFO
            //     External parameters with the contents of radRBFOPtr. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadExternalRBFOLowGain ( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RBFO_T_PTR radRBFOPtr ) LEP_RESULT LEP_SetRadExternalRBFOLowGain ( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RBFO_T_PTR radRBFOPtr ) /* RBFO */ typedef struct LEP_RBFO_T_TAG
            //     { // value is not scaled // value is scaled by X << n LEP_UINT32 RBFO_F; LEP_INT32
            //     RBFO_O; }LEP_RBFO_T, *LEP_RBFO_T_PTR;
            public Rbfo GetExternalRBFOLowGainChecked();
            //
            // Сводка:
            //     RAD Flux Linear Parameters
            //     These functions either get or set various scene parameters used in the T-Linear
            //     calculations.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     sceneEmissivity – 82 – 8192 – 8192 – 8192 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TBkgK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     tauWindow – 82 – 8192 – 8192 – 8192 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TWindowK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     tauAtm – 82 – 8192 – 8192 – 8192 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TAtmK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     reflWindow – 0 – 8192–tauWindow – 0 – 0 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TReflK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xBD
            //     SDK Data Length: Get 8 size of LEP_RAD_FLUX_LINEAR_PARAMS_T data type
            //     Set 8 size of LEP_RAD_FLUX_LINEAR_PARAMS_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadFluxLinearParams() – Updates fluxParamsPtr with the
            //     camera’s Radiometry scene parameters used for T-Linear calculation. –
            //     Lepton 2.5, 3.5 – LEP_SetRadFluxLinearParams() – Updates the Camera’s current
            //     Radiometry scene parameters with the contents of fluxParams. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadFluxLinearParams (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_FLUX_LINEAR_PARAMS_T_PTR fluxParamsPtr) LEP_RESULT LEP_SetRadFluxLinearParams
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_FLUX_LINEAR_PARAMS_T fluxParams)
            //     /* Radiometry Flux Linear Params */ typedef struct LEP_RAD_FLUX_LINEAR_PARAMS_T_TAG
            //     { /* Type Field name format comment */ /* 3.13 */ /* 16.0 value in Kelvin 100x
            //     */ /* 3.13 */ /* 16.0 value in Kelvin 100x */ /* 3.13 */ /* 16.0 value in Kelvin
            //     100x */ /* 3.13 */ /* 16.0 value in Kelvin 100x */ }LEP_RAD_FLUX_LINEAR_PARAMS_T,
            //     *LEP_RAD_FLUX_LINEAR_PARAMS_T_PTR;
            public FluxLinearParams GetFluxLinearParams();
            //
            // Сводка:
            //     RAD Flux Linear Parameters
            //     These functions either get or set various scene parameters used in the T-Linear
            //     calculations.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     sceneEmissivity – 82 – 8192 – 8192 – 8192 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TBkgK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     tauWindow – 82 – 8192 – 8192 – 8192 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TWindowK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     tauAtm – 82 – 8192 – 8192 – 8192 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TAtmK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     reflWindow – 0 – 8192–tauWindow – 0 – 0 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TReflK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xBD
            //     SDK Data Length: Get 8 size of LEP_RAD_FLUX_LINEAR_PARAMS_T data type
            //     Set 8 size of LEP_RAD_FLUX_LINEAR_PARAMS_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadFluxLinearParams() – Updates fluxParamsPtr with the
            //     camera’s Radiometry scene parameters used for T-Linear calculation. –
            //     Lepton 2.5, 3.5 – LEP_SetRadFluxLinearParams() – Updates the Camera’s current
            //     Radiometry scene parameters with the contents of fluxParams. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadFluxLinearParams (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_FLUX_LINEAR_PARAMS_T_PTR fluxParamsPtr) LEP_RESULT LEP_SetRadFluxLinearParams
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_FLUX_LINEAR_PARAMS_T fluxParams)
            //     /* Radiometry Flux Linear Params */ typedef struct LEP_RAD_FLUX_LINEAR_PARAMS_T_TAG
            //     { /* Type Field name format comment */ /* 3.13 */ /* 16.0 value in Kelvin 100x
            //     */ /* 3.13 */ /* 16.0 value in Kelvin 100x */ /* 3.13 */ /* 16.0 value in Kelvin
            //     100x */ /* 3.13 */ /* 16.0 value in Kelvin 100x */ }LEP_RAD_FLUX_LINEAR_PARAMS_T,
            //     *LEP_RAD_FLUX_LINEAR_PARAMS_T_PTR;
            public FluxLinearParams GetFluxLinearParamsChecked();
            public ushort GetFNumber();
            public ushort GetFNumberChecked();
            public ushort GetFrameMedianPixelValue();
            public ushort GetFrameMedianPixelValueChecked();
            public ushort GetGlobalGain();
            public ushort GetGlobalGainChecked();
            public ushort GetGlobalGainFFC();
            public ushort GetGlobalGainFFCChecked();
            public ushort GetGlobalOffset();
            public ushort GetGlobalOffsetChecked();
            public LinearTempCorrection GetHousingTcp();
            public LinearTempCorrection GetHousingTcpChecked();
            public Rbfo GetInternalRBFOHighGain();
            public Rbfo GetInternalRBFOHighGainChecked();
            public Rbfo GetInternalRBFOLowGain();
            public Rbfo GetInternalRBFOLowGainChecked();
            public LinearTempCorrection GetLensTcp();
            public LinearTempCorrection GetLensTcpChecked();
            public int GetMffcFlux();
            public int GetMffcFluxChecked();
            public SignedLut128 GetMLGLut();
            public SignedLut128 GetMLGLutChecked();
            public ushort GetPreviousGlobalGain();
            public ushort GetPreviousGlobalGainChecked();
            public ushort GetPreviousGlobalOffset();
            public ushort GetPreviousGlobalOffsetChecked();
            public RadioCalValues GetRadioCalValues();
            public RadioCalValues GetRadioCalValuesChecked();
            public ushort GetRadometryFilter();
            public ushort GetRadometryFilterChecked();
            //
            // Сводка:
            //     RAD RBFO External Parameters
            //     This function gets and sets the radiometry RBFO External parameters. The RBFO
            //     parameters define the equation for conversion between flux and temperature.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     R – 10000 – 1000000 – 395653 – Calibrated per camera – N/A – 1 –
            //     B – 1200000 – 1700000 – 1428000 – Calibrated per camera – N/A – 1000 –
            //     F – 500 – 3000 – 1000 – Calibrated per camera – N/A – 1000 –
            //     O – -16384000 – 16383000 – 156000 – Calibrated per camera – N/A – 1000 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x04
            //     With Set 0x05
            //     SDK Data Length: Get 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Set 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadRBFOExternal0() – Updates radRBFOPtr with
            //     the Camera’s current RBFO External parameters. –
            //     All Lepton Configurations – LEP_SetRadRBFOExternal0() – Updates the Camera’s
            //     RBFO External parameters with the contents of radRBFOPtr. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadRBFOExternal0( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RBFO_T_PTR
            //     radRBFOPtr ) LEP_RESULT LEP_SetRadRBFOExternal0( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RBFO_T_PTR radRBFOPtr ) /* RBFO */ typedef struct LEP_RBFO_T_TAG { // value
            //     is not scaled // value is scaled by X << n LEP_UINT32 RBFO_F; LEP_INT32 RBFO_O;
            //     }LEP_RBFO_T, *LEP_RBFO_T_PTR;
            public Rbfo GetRBFOExternal0();
            //
            // Сводка:
            //     RAD RBFO External Parameters
            //     This function gets and sets the radiometry RBFO External parameters. The RBFO
            //     parameters define the equation for conversion between flux and temperature.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     R – 10000 – 1000000 – 395653 – Calibrated per camera – N/A – 1 –
            //     B – 1200000 – 1700000 – 1428000 – Calibrated per camera – N/A – 1000 –
            //     F – 500 – 3000 – 1000 – Calibrated per camera – N/A – 1000 –
            //     O – -16384000 – 16383000 – 156000 – Calibrated per camera – N/A – 1000 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x04
            //     With Set 0x05
            //     SDK Data Length: Get 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Set 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadRBFOExternal0() – Updates radRBFOPtr with
            //     the Camera’s current RBFO External parameters. –
            //     All Lepton Configurations – LEP_SetRadRBFOExternal0() – Updates the Camera’s
            //     RBFO External parameters with the contents of radRBFOPtr. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadRBFOExternal0( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RBFO_T_PTR
            //     radRBFOPtr ) LEP_RESULT LEP_SetRadRBFOExternal0( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RBFO_T_PTR radRBFOPtr ) /* RBFO */ typedef struct LEP_RBFO_T_TAG { // value
            //     is not scaled // value is scaled by X << n LEP_UINT32 RBFO_F; LEP_INT32 RBFO_O;
            //     }LEP_RBFO_T, *LEP_RBFO_T_PTR;
            public Rbfo GetRBFOExternal0Checked();
            public Rbfo GetRBFOInternal0();
            public Rbfo GetRBFOInternal0Checked();
            public ushort GetResponsivityShift();
            public ushort GetResponsivityShiftChecked();
            public Lut128 GetResponsivityValueLut();
            public Lut128 GetResponsivityValueLutChecked();
            //
            // Сводка:
            //     RAD Run Status
            //     This function obtains the current status of a RAD module run operation. This
            //     function is used whenever a RAD command is issued that executes an operation
            //     like the run FFC. Typically, the host polls the status to determine when the
            //     command has completed. If the return value is negative, then the operation completed
            //     with an error. Positive values indicate an in-process state.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_RAD_STATUS_ERROR – LEP_RAD_FRAME_AVERAGE_COLLECTING_FRAMES – LEP_RAD_STATUS_READY
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0E00
            //     SDK Command ID: Base With Run 0x30
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadRunStatus() – Gets the Current RAD run
            //     operation status. Updates radStatusPtr with current value of the run status –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadRunStatus( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_STATUS_E_PTR
            //     radStatusPtr ) /* Run operation status */ typedef enum { LEP_RAD_STATUS_ERROR
            //     = -1, LEP_RAD_STATUS_READY = 0, LEP_RAD_STATUS_BUSY, LEP_RAD_FRAME_AVERAGE_COLLECTING_FRAMES,
            //     LEP_RAD_STATUS_END } LEP_RAD_STATUS_E, *LEP_RAD_STATUS_E_PTR;
            public Status GetRunStatus();
            //
            // Сводка:
            //     RAD Run Status
            //     This function obtains the current status of a RAD module run operation. This
            //     function is used whenever a RAD command is issued that executes an operation
            //     like the run FFC. Typically, the host polls the status to determine when the
            //     command has completed. If the return value is negative, then the operation completed
            //     with an error. Positive values indicate an in-process state.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_RAD_STATUS_ERROR – LEP_RAD_FRAME_AVERAGE_COLLECTING_FRAMES – LEP_RAD_STATUS_READY
            //     – N/A – N/A –
            //     SDK Module ID: OEM 0x0E00
            //     SDK Command ID: Base With Run 0x30
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadRunStatus() – Gets the Current RAD run
            //     operation status. Updates radStatusPtr with current value of the run status –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadRunStatus( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_STATUS_E_PTR
            //     radStatusPtr ) /* Run operation status */ typedef enum { LEP_RAD_STATUS_ERROR
            //     = -1, LEP_RAD_STATUS_READY = 0, LEP_RAD_STATUS_BUSY, LEP_RAD_FRAME_AVERAGE_COLLECTING_FRAMES,
            //     LEP_RAD_STATUS_END } LEP_RAD_STATUS_E, *LEP_RAD_STATUS_E_PTR;
            public Status GetRunStatusChecked();
            public LinearTempCorrection GetShutterTcp();
            public LinearTempCorrection GetShutterTcpChecked();
            public ushort GetSnfScaleFactor();
            public ushort GetSnfScaleFactorChecked();
            //
            // Сводка:
            //     RAD Spotmeter Value
            //     These functions get the mean, min, and max temperature values for pixels within
            //     the spotmeter ROI.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     radSpotmeterValue
            //     – 0 – 65535 – N/A – Kelvin – 10 or 100 (dependent on TLinear Resolution) –
            //     radSpotmeterMaxValue
            //     – 0 – 65535 – N/A – Kelvin – 10 or 100 (dependent on TLinear Resolution) –
            //     radSpotmeterMinValue
            //     – 0 – 65535 – N/A – Kelvin – 10 or 100 (dependent on TLinear Resolution) –
            //     radSpotmeterPopulation
            //     – 0 – 4800 – N/A – Pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     radSpotmeterValue
            //     – 0 – 65535 – N/A – Kelvin – 10 or 100 (dependent on TLinear Resolution) –
            //     radSpotmeterMaxValue
            //     – 0 – 65535 – N/A – Kelvin – 10 or 100 (dependent on TLinear Resolution) –
            //     radSpotmeterMinValue
            //     – 0 – 65535 – N/A – Kelvin – 10 or 100 (dependent on TLinear Resolution) –
            //     radSpotmeterPopulation
            //     – 0 – 19200 – N/A – Pixels – 1 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0xD0
            //     SDK Data Length: Get 4 size of LEP_RAD_SPOTMETER_OBJ_KELVIN_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadSpotmeterObjInKelvinX100() – Updates kelvinPtr with
            //     the camera’s current spotmeter values. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadSpotmeterObjInKelvinX100 (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_SPOTMETER_OBJ_KELVIN_T_PTR kelvinPtr) /* Radiometry ROI */ typedef LEP_UINT16
            //     LEP_RAD_SPOTMETER_KELVIN_T, *LEP_RAD_SPOTMETER_KELVIN_T_PTR; typedef struct LEP_RAD_SPOTMETER_OBJ_KELVIN_T_TAG
            //     { LEP_RAD_SPOTMETER_KELVIN_T radSpotmeterValue; LEP_UINT16 radSpotmeterMaxValue;
            //     LEP_UINT16 radSpotmeterMinValue; LEP_UINT16 radSpotmeterPopulation; }LEP_RAD_SPOTMETER_OBJ_KELVIN_T,
            //     *LEP_RAD_SPOTMETER_OBJ_KELVIN_T_PTR;
            public SpotmeterObjKelvin GetSpotmeterObjInKelvinX100();
            //
            // Сводка:
            //     RAD Spotmeter Value
            //     These functions get the mean, min, and max temperature values for pixels within
            //     the spotmeter ROI.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     radSpotmeterValue
            //     – 0 – 65535 – N/A – Kelvin – 10 or 100 (dependent on TLinear Resolution) –
            //     radSpotmeterMaxValue
            //     – 0 – 65535 – N/A – Kelvin – 10 or 100 (dependent on TLinear Resolution) –
            //     radSpotmeterMinValue
            //     – 0 – 65535 – N/A – Kelvin – 10 or 100 (dependent on TLinear Resolution) –
            //     radSpotmeterPopulation
            //     – 0 – 4800 – N/A – Pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     radSpotmeterValue
            //     – 0 – 65535 – N/A – Kelvin – 10 or 100 (dependent on TLinear Resolution) –
            //     radSpotmeterMaxValue
            //     – 0 – 65535 – N/A – Kelvin – 10 or 100 (dependent on TLinear Resolution) –
            //     radSpotmeterMinValue
            //     – 0 – 65535 – N/A – Kelvin – 10 or 100 (dependent on TLinear Resolution) –
            //     radSpotmeterPopulation
            //     – 0 – 19200 – N/A – Pixels – 1 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0xD0
            //     SDK Data Length: Get 4 size of LEP_RAD_SPOTMETER_OBJ_KELVIN_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadSpotmeterObjInKelvinX100() – Updates kelvinPtr with
            //     the camera’s current spotmeter values. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadSpotmeterObjInKelvinX100 (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_SPOTMETER_OBJ_KELVIN_T_PTR kelvinPtr) /* Radiometry ROI */ typedef LEP_UINT16
            //     LEP_RAD_SPOTMETER_KELVIN_T, *LEP_RAD_SPOTMETER_KELVIN_T_PTR; typedef struct LEP_RAD_SPOTMETER_OBJ_KELVIN_T_TAG
            //     { LEP_RAD_SPOTMETER_KELVIN_T radSpotmeterValue; LEP_UINT16 radSpotmeterMaxValue;
            //     LEP_UINT16 radSpotmeterMinValue; LEP_UINT16 radSpotmeterPopulation; }LEP_RAD_SPOTMETER_OBJ_KELVIN_T,
            //     *LEP_RAD_SPOTMETER_OBJ_KELVIN_T_PTR;
            public SpotmeterObjKelvin GetSpotmeterObjInKelvinX100Checked();
            //
            // Сводка:
            //     RAD Spotmeter Region of Interest (ROI)
            //     These functions either get or set a rectangular region of interest within the
            //     video frame extents which RAD operations can use to calculate temperature measurement
            //     minimum, maximum, and average.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column-1 – 39 – pixels – 1 –
            //     start row
            //     – 0 – < end row-1 – 29 – pixels – 1 –
            //     end column
            //     – > start column+1 – 79 – 40 – pixels – 1 –
            //     end row
            //     – > start row+1 – 59 – 30 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column-1 – 79 – pixels – 1 –
            //     start row
            //     – 0 – < end row-1 – 59 – pixels – 1 –
            //     end column
            //     – > start column+1 – 159 – 80 – pixels – 1 –
            //     end row
            //     – > start row+1 – 119 – 60 – pixels – 1 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xCD
            //     SDK Data Length: Get 4 size of LEP_RAD_ROI_T data type
            //     Set 4 size of LEP_RAD_ROI_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadSpotmeterRoi() – Updates spotmeterRoiPtr with the
            //     camera’s current spotmeter ROI. –
            //     Lepton 2.5, 3.5 – LEP_SetRadSpotmeterRoi() – Updates the Camera’s current spotmeter
            //     ROI with the contents of spotmeterRoi. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadSpotmeterRoi (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ROI_T_PTR
            //     spotmeterRoiPtr) LEP_RESULT LEP_SetRadSpotmeterRoi (LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RAD_ROI_T spotmeterRoi) /* Radiometry ROI */ typedef struct
            //     LEP_RAD_ROI_T_TAG { LEP_UINT16 startRow; LEP_UINT16 startCol; LEP_UINT16 endRow;
            //     LEP_UINT16 endCol; }LEP_RAD_ROI_T, *LEP_RAD_ROI_T_PTR;
            public Roi GetSpotmeterRoi();
            //
            // Сводка:
            //     RAD Spotmeter Region of Interest (ROI)
            //     These functions either get or set a rectangular region of interest within the
            //     video frame extents which RAD operations can use to calculate temperature measurement
            //     minimum, maximum, and average.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column-1 – 39 – pixels – 1 –
            //     start row
            //     – 0 – < end row-1 – 29 – pixels – 1 –
            //     end column
            //     – > start column+1 – 79 – 40 – pixels – 1 –
            //     end row
            //     – > start row+1 – 59 – 30 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column-1 – 79 – pixels – 1 –
            //     start row
            //     – 0 – < end row-1 – 59 – pixels – 1 –
            //     end column
            //     – > start column+1 – 159 – 80 – pixels – 1 –
            //     end row
            //     – > start row+1 – 119 – 60 – pixels – 1 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xCD
            //     SDK Data Length: Get 4 size of LEP_RAD_ROI_T data type
            //     Set 4 size of LEP_RAD_ROI_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadSpotmeterRoi() – Updates spotmeterRoiPtr with the
            //     camera’s current spotmeter ROI. –
            //     Lepton 2.5, 3.5 – LEP_SetRadSpotmeterRoi() – Updates the Camera’s current spotmeter
            //     ROI with the contents of spotmeterRoi. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadSpotmeterRoi (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ROI_T_PTR
            //     spotmeterRoiPtr) LEP_RESULT LEP_SetRadSpotmeterRoi (LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RAD_ROI_T spotmeterRoi) /* Radiometry ROI */ typedef struct
            //     LEP_RAD_ROI_T_TAG { LEP_UINT16 startRow; LEP_UINT16 startCol; LEP_UINT16 endRow;
            //     LEP_UINT16 endCol; }LEP_RAD_ROI_T, *LEP_RAD_ROI_T_PTR;
            public Roi GetSpotmeterRoiChecked();
            public ushort GetTauLens();
            public ushort GetTauLensChecked();
            public Lut256 GetTAuxCLut();
            public Lut256 GetTAuxCLutChecked();
            public ushort GetTAuxCts();
            public ushort GetTAuxCtsChecked();
            public TemperatureUpdate GetTAuxCtsMode();
            public TemperatureUpdate GetTAuxCtsModeChecked();
            public Lut256 GetTAuxLut();
            public Lut256 GetTAuxLutChecked();
            public int GetTEqShutterFlux();
            public int GetTEqShutterFluxChecked();
            public Lut128 GetTEqShutterLut();
            public Lut128 GetTEqShutterLutChecked();
            public Lut256 GetTFpaCLut();
            public Lut256 GetTFpaCLutChecked();
            public ushort GetTFpaCts();
            public ushort GetTFpaCtsChecked();
            public TemperatureUpdate GetTFpaCtsMode();
            public TemperatureUpdate GetTFpaCtsModeChecked();
            public Lut256 GetTFpaLut();
            public Lut256 GetTFpaLutChecked();
            //
            // Сводка:
            //     RAD T-Linear Auto Resolution
            //     These functions either get or set the T-Linear automatic resolution enable state.
            //     When enabled, T-Linear output resolution is chosen automatically based on scene
            //     statistics and gain mode.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     enableState – LEP_RAD_DISABLE – LEP_RAD_ENABLE – LEP_RAD_DISABLE – N/A – N/A
            //     –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xC9
            //     SDK Data Length: Get 2 size of an Enum data type on a 32-bit machine
            //     Set 2 size of an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadTLinearAutoResolution() – Updates enableStatePtr
            //     with the camera’s T-Linear automatic resolution feature enable state. –
            //     Lepton 2.5, 3.5 – LEP_SetRadTLinearAutoResolution() – Updates the Camera’s current
            //     T-Linear automatic resolution feature with the contents of enableState. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTLinearAutoResolution (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_ENABLE_E_PTR enableStatePtr) LEP_RESULT LEP_SetRadTLinearAutoResolution
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ENABLE_E enableState) /* Radiometry
            //     Enable state */ typedef enum LEP_RAD_ENABLE_E_TAG { LEP_RAD_DISABLE = 0, LEP_RAD_ENABLE,
            //     LEP_END_RAD_ENABLE }LEP_RAD_ENABLE_E, *LEP_RAD_ENABLE_E_PTR;
            public Enable GetTLinearAutoResolution();
            //
            // Сводка:
            //     RAD T-Linear Auto Resolution
            //     These functions either get or set the T-Linear automatic resolution enable state.
            //     When enabled, T-Linear output resolution is chosen automatically based on scene
            //     statistics and gain mode.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     enableState – LEP_RAD_DISABLE – LEP_RAD_ENABLE – LEP_RAD_DISABLE – N/A – N/A
            //     –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xC9
            //     SDK Data Length: Get 2 size of an Enum data type on a 32-bit machine
            //     Set 2 size of an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadTLinearAutoResolution() – Updates enableStatePtr
            //     with the camera’s T-Linear automatic resolution feature enable state. –
            //     Lepton 2.5, 3.5 – LEP_SetRadTLinearAutoResolution() – Updates the Camera’s current
            //     T-Linear automatic resolution feature with the contents of enableState. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTLinearAutoResolution (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_ENABLE_E_PTR enableStatePtr) LEP_RESULT LEP_SetRadTLinearAutoResolution
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ENABLE_E enableState) /* Radiometry
            //     Enable state */ typedef enum LEP_RAD_ENABLE_E_TAG { LEP_RAD_DISABLE = 0, LEP_RAD_ENABLE,
            //     LEP_END_RAD_ENABLE }LEP_RAD_ENABLE_E, *LEP_RAD_ENABLE_E_PTR;
            public Enable GetTLinearAutoResolutionChecked();
            //
            // Сводка:
            //     RAD T-Linear Enable State
            //     These functions either get or set the T-Linear output enable state. When enabled,
            //     the video output represents temperature in Kelvin with some scale factor defined
            //     by the T-linear Resolution parameter. T-Linear mode requires radiometry mode
            //     (temperature stable output) to also be enabled.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     enableState – LEP_RAD_DISABLE – LEP_RAD_ENABLE – LEP_RAD_DISABLE – LEP_RAD_ENABLE
            //     – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xC1
            //     SDK Data Length: Get 2 size of an Enum data type on a 32-bit machine
            //     Set 2 size of an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadTLinearEnableState() – Updates enableStatePtr with
            //     the camera’s T-Linear calculation enable state. –
            //     Lepton 2.5, 3.5 – LEP_SetRadTLinearEnableState() – Updates the Camera’s current
            //     T-Linear calculation enable state with the contents of enableState. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTLinearEnableState (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_ENABLE_E_PTR enableStatePtr) LEP_RESULT LEP_SetRadTLinearEnableState
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ENABLE_E enableState) /* Radiometry
            //     Enable state */ typedef enum LEP_RAD_ENABLE_E_TAG { LEP_RAD_DISABLE = 0, LEP_RAD_ENABLE,
            //     LEP_END_RAD_ENABLE }LEP_RAD_ENABLE_E, *LEP_RAD_ENABLE_E_PTR;
            public Enable GetTLinearEnableState();
            //
            // Сводка:
            //     RAD T-Linear Enable State
            //     These functions either get or set the T-Linear output enable state. When enabled,
            //     the video output represents temperature in Kelvin with some scale factor defined
            //     by the T-linear Resolution parameter. T-Linear mode requires radiometry mode
            //     (temperature stable output) to also be enabled.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     enableState – LEP_RAD_DISABLE – LEP_RAD_ENABLE – LEP_RAD_DISABLE – LEP_RAD_ENABLE
            //     – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xC1
            //     SDK Data Length: Get 2 size of an Enum data type on a 32-bit machine
            //     Set 2 size of an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadTLinearEnableState() – Updates enableStatePtr with
            //     the camera’s T-Linear calculation enable state. –
            //     Lepton 2.5, 3.5 – LEP_SetRadTLinearEnableState() – Updates the Camera’s current
            //     T-Linear calculation enable state with the contents of enableState. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTLinearEnableState (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_ENABLE_E_PTR enableStatePtr) LEP_RESULT LEP_SetRadTLinearEnableState
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ENABLE_E enableState) /* Radiometry
            //     Enable state */ typedef enum LEP_RAD_ENABLE_E_TAG { LEP_RAD_DISABLE = 0, LEP_RAD_ENABLE,
            //     LEP_END_RAD_ENABLE }LEP_RAD_ENABLE_E, *LEP_RAD_ENABLE_E_PTR;
            public Enable GetTLinearEnableStateChecked();
            //
            // Сводка:
            //     RAD T-Linear Resolution
            //     These functions either get or set the T-Linear output resolution, which defines
            //     the scale factor for the temperature measurements contained in the video output
            //     (per-pixel) with T-Linear mode enabled.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default –
            //     resolution – LEP_RAD_RESOLUTION_0_1 – LEP_RAD_RESOLUTION_0_01 – LEP_RAD_RESOLUTION_0_1
            //     – LEP_RAD_RESOLUTION_0_01 –
            //     Setting – Minimum Pixel Value – Maximum Pixel Value – Units – Scale factor –
            //     LEP_RAD_RESOLUTION_0_1 – 0 – 65535 – Kelvin –
            //     10
            //     (65535 = 6553.5K)
            //     –
            //     LEP_RAD_RESOLUTION_0_01 – 0 – 65535 – Kelvin –
            //     100
            //     (65535 = 655.35K)
            //     –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xC5
            //     SDK Data Length: Get 2 size of an Enum data type on a 32-bit machine
            //     Set 2 size of an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadTLinearResolution() – Updates resolutionPtr with
            //     the camera’s T-Linear calculation resolution. –
            //     Lepton 2.5, 3.5 – LEP_SetRadTLinearResolution() – Updates the Camera’s current
            //     T-Linear calculation resolution with the contents of resolution. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTLinearResolution (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_TLINEAR_RESOLUTION_E_PTR resolutionPtr) LEP_RESULT LEP_SetRadTLinearResolution
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_TLINEAR_RESOLUTION_E resolution)
            //     /* Radiometry T-Linear Resolution */ typedef enum LEP_RAD_TLINEAR_RESOLUTION_E_TAG
            //     { LEP_RAD_RESOLUTION_0_1 = 0, LEP_RAD_RESOLUTION_0_01, LEP_RAD_END_RESOLUTION
            //     }LEP_RAD_TLINEAR_RESOLUTION_E, *LEP_RAD_TLINEAR_RESOLUTION_E_PTR;
            public TlinearResolution GetTLinearResolution();
            //
            // Сводка:
            //     RAD T-Linear Resolution
            //     These functions either get or set the T-Linear output resolution, which defines
            //     the scale factor for the temperature measurements contained in the video output
            //     (per-pixel) with T-Linear mode enabled.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default –
            //     resolution – LEP_RAD_RESOLUTION_0_1 – LEP_RAD_RESOLUTION_0_01 – LEP_RAD_RESOLUTION_0_1
            //     – LEP_RAD_RESOLUTION_0_01 –
            //     Setting – Minimum Pixel Value – Maximum Pixel Value – Units – Scale factor –
            //     LEP_RAD_RESOLUTION_0_1 – 0 – 65535 – Kelvin –
            //     10
            //     (65535 = 6553.5K)
            //     –
            //     LEP_RAD_RESOLUTION_0_01 – 0 – 65535 – Kelvin –
            //     100
            //     (65535 = 655.35K)
            //     –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xC5
            //     SDK Data Length: Get 2 size of an Enum data type on a 32-bit machine
            //     Set 2 size of an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadTLinearResolution() – Updates resolutionPtr with
            //     the camera’s T-Linear calculation resolution. –
            //     Lepton 2.5, 3.5 – LEP_SetRadTLinearResolution() – Updates the Camera’s current
            //     T-Linear calculation resolution with the contents of resolution. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTLinearResolution (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_TLINEAR_RESOLUTION_E_PTR resolutionPtr) LEP_RESULT LEP_SetRadTLinearResolution
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_TLINEAR_RESOLUTION_E resolution)
            //     /* Radiometry T-Linear Resolution */ typedef enum LEP_RAD_TLINEAR_RESOLUTION_E_TAG
            //     { LEP_RAD_RESOLUTION_0_1 = 0, LEP_RAD_RESOLUTION_0_01, LEP_RAD_END_RESOLUTION
            //     }LEP_RAD_TLINEAR_RESOLUTION_E, *LEP_RAD_TLINEAR_RESOLUTION_E_PTR;
            public TlinearResolution GetTLinearResolutionChecked();
            public ushort GetTnfScaleFactor();
            public ushort GetTnfScaleFactorChecked();
            //
            // Сводка:
            //     RAD TShutter Temperature
            //     This function gets or sets the TShutter temperature. The TShutter temperature
            //     is used at FFC when the TShutter Mode is “User”.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     radTShutter – 0 – 65535 – 30000 – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x28
            //     With Set 0x29
            //     SDK Data Length: Get 1 size of LEP_RAD_KELVIN_T data type
            //     Set 1 size of LEP_RAD_KELVIN_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadTShutter() – Updates radTShutterPtr with
            //     current TShutter temperature –
            //     All Lepton Configurations – LEP_SetRadTShutter() – Updates the Camera’s current
            //     TShutter temperature with the contents of radTShutter. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTShutter( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_KELVIN_T_PTR
            //     radTShutterPtr ) LEP_RESULT LEP_SetRadTShutter( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_KELVIN_T radTShutter ) /* TShutter value is 100xKelvin [16.0] */ typedef
            //     LEP_UINT16 LEP_RAD_KELVIN_T, *LEP_RAD_KELVIN_T_PTR;
            public ushort GetTShutter();
            //
            // Сводка:
            //     RAD TShutter Temperature
            //     This function gets or sets the TShutter temperature. The TShutter temperature
            //     is used at FFC when the TShutter Mode is “User”.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     radTShutter – 0 – 65535 – 30000 – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x28
            //     With Set 0x29
            //     SDK Data Length: Get 1 size of LEP_RAD_KELVIN_T data type
            //     Set 1 size of LEP_RAD_KELVIN_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadTShutter() – Updates radTShutterPtr with
            //     current TShutter temperature –
            //     All Lepton Configurations – LEP_SetRadTShutter() – Updates the Camera’s current
            //     TShutter temperature with the contents of radTShutter. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTShutter( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_KELVIN_T_PTR
            //     radTShutterPtr ) LEP_RESULT LEP_SetRadTShutter( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_KELVIN_T radTShutter ) /* TShutter value is 100xKelvin [16.0] */ typedef
            //     LEP_UINT16 LEP_RAD_KELVIN_T, *LEP_RAD_KELVIN_T_PTR;
            public ushort GetTShutterChecked();
            //
            // Сводка:
            //     RAD TShutter Mode
            //     This function gets or sets the TShutter mode. The TShutter mode specifies how
            //     TShutter value is obtained at FFC.
            //
            // Примечания:
            //     User: Use the TShutter value set with LEP_SetRadTShutter()
            //     Cal: Use TEqShutter from calibration
            //     Fixed: the shutter temperature is considered static, and therefore the spotmeter
            //     is not updated at FFC
            //     – Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     radTShutterMode – FLR_RAD_TS_USER_MODE – FLR_RAD_TS_FIXED_MODE – FLR_RAD_TS_CAL_MODE
            //     – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadTShutterMode() – Updates radTShutterModePtr
            //     with current TShutter mode –
            //     All Lepton Configurations – LEP_SetRadTShutterMode() – Updates the Camera’s current
            //     TShutter mode with the contents of radTShutterMode. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTShutterMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_TS_MODE_E_PTR
            //     radTShutterModePtr ) LEP_RESULT LEP_SetRadTShutterMode( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RAD_TS_MODE_E radTShutterMode ) /* TShutter Modes */ typedef
            //     enum FLR_RAD_TS_MODE_E_TAG { FLR_RAD_TS_USER_MODE = 0, FLR_RAD_TS_CAL_MODE, FLR_RAD_TS_FIXED_MODE,
            //     FLR_RAD_TS_END_TS_MODE }FLR_RAD_TS_MODE_E, *FLR_RAD_TS_MODE_E_PTR;
            public TsMode GetTShutterMode();
            //
            // Сводка:
            //     RAD TShutter Mode
            //     This function gets or sets the TShutter mode. The TShutter mode specifies how
            //     TShutter value is obtained at FFC.
            //
            // Примечания:
            //     User: Use the TShutter value set with LEP_SetRadTShutter()
            //     Cal: Use TEqShutter from calibration
            //     Fixed: the shutter temperature is considered static, and therefore the spotmeter
            //     is not updated at FFC
            //     – Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     radTShutterMode – FLR_RAD_TS_USER_MODE – FLR_RAD_TS_FIXED_MODE – FLR_RAD_TS_CAL_MODE
            //     – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadTShutterMode() – Updates radTShutterModePtr
            //     with current TShutter mode –
            //     All Lepton Configurations – LEP_SetRadTShutterMode() – Updates the Camera’s current
            //     TShutter mode with the contents of radTShutterMode. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTShutterMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_TS_MODE_E_PTR
            //     radTShutterModePtr ) LEP_RESULT LEP_SetRadTShutterMode( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RAD_TS_MODE_E radTShutterMode ) /* TShutter Modes */ typedef
            //     enum FLR_RAD_TS_MODE_E_TAG { FLR_RAD_TS_USER_MODE = 0, FLR_RAD_TS_CAL_MODE, FLR_RAD_TS_FIXED_MODE,
            //     FLR_RAD_TS_END_TS_MODE }FLR_RAD_TS_MODE_E, *FLR_RAD_TS_MODE_E_PTR;
            public TsMode GetTShutterModeChecked();
            //
            // Сводка:
            //     RAD FFC Normalization
            //     This command executes a Flat-Field Correction (FFC) and updates the Global Gain
            //     and Global Offset. The target value is factory set and should not be changed
            //     under normal circumstances. The Run command executes an FFC using currently active
            //     values for the FFC normalization target and number of frames to average (see
            //     4.4.21). This command executes synchronously. Poll the RAD Run Status to determine
            //     when this command completes (see 4.7.7).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     N/A – N/A – N/A – N/A – N/A –
            //     SDK Module ID: SYS 0x0E00
            //     SDK Command ID: Base With Run 0x2E
            //     SDK Data Length: Run 0 size of a Run command
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunRadFFC() – Executes the FFC normalization
            //     using previously specified normalization target value and calculates the Global
            //     Gain and Global Offset –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunRadFFC( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr )
            public void RunFFC();
            //
            // Сводка:
            //     RAD FFC Normalization
            //     This command executes a Flat-Field Correction (FFC) and updates the Global Gain
            //     and Global Offset. The target value is factory set and should not be changed
            //     under normal circumstances. The Run command executes an FFC using currently active
            //     values for the FFC normalization target and number of frames to average (see
            //     4.4.21). This command executes synchronously. Poll the RAD Run Status to determine
            //     when this command completes (see 4.7.7).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     N/A – N/A – N/A – N/A – N/A –
            //     SDK Module ID: SYS 0x0E00
            //     SDK Command ID: Base With Run 0x2E
            //     SDK Data Length: Run 0 size of a Run command
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunRadFFC() – Executes the FFC normalization
            //     using previously specified normalization target value and calculates the Global
            //     Gain and Global Offset –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunRadFFC( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr )
            public void RunFFCChecked();
            public void SetArbitraryOffset(short source);
            public void SetArbitraryOffsetChecked(short source);
            public void SetArbitraryOffsetMode(ArbitraryOffsetMode source);
            public void SetArbitraryOffsetModeChecked(ArbitraryOffsetMode source);
            public void SetArbitraryOffsetParams(ArbitraryOffsetParams source);
            public void SetArbitraryOffsetParamsChecked(ArbitraryOffsetParams source);
            public void SetDebugFlux(int source);
            public void SetDebugFluxChecked(int source);
            public void SetDebugTemp(ushort source);
            public void SetDebugTempChecked(ushort source);
            //
            // Сводка:
            //     RAD Radiometry Control Enable
            //     This function enables or disables the Camera Radiometry Control (temperature
            //     stable output), or returns the state of Control.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     radEnableState – LEP_RAD_DISABLE – LEP_RAD_ENABLE – LEP_RAD_DISABLE – LEP_RAD_ENABLE
            //     – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x10
            //     With Set 0x11
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine value
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadEnableState() – Updates radEnableStatePtr
            //     with current state of the radiometry control. –
            //     All Lepton Configurations – LEP_SetRadEnableState() – Updates the Camera’s with
            //     current state of the radiometry control with the contents of radEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadEnableState( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ENABLE_E_PTR
            //     radEnableStatePtr ) LEP_RESULT LEP_SetRadEnableState( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RAD_ENABLE_E radEnableState ) /* Radiometry Enable state */
            //     typedef enum LEP_RAD_ENABLE_E_TAG { LEP_RAD_DISABLE = 0, LEP_RAD_ENABLE, LEP_END_RAD_ENABLE
            //     }LEP_RAD_ENABLE_E, *LEP_RAD_ENABLE_E_PTR;
            public void SetEnableState(Enable source);
            //
            // Сводка:
            //     RAD Radiometry Control Enable
            //     This function enables or disables the Camera Radiometry Control (temperature
            //     stable output), or returns the state of Control.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     radEnableState – LEP_RAD_DISABLE – LEP_RAD_ENABLE – LEP_RAD_DISABLE – LEP_RAD_ENABLE
            //     – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x10
            //     With Set 0x11
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine value
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadEnableState() – Updates radEnableStatePtr
            //     with current state of the radiometry control. –
            //     All Lepton Configurations – LEP_SetRadEnableState() – Updates the Camera’s with
            //     current state of the radiometry control with the contents of radEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadEnableState( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ENABLE_E_PTR
            //     radEnableStatePtr ) LEP_RESULT LEP_SetRadEnableState( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RAD_ENABLE_E radEnableState ) /* Radiometry Enable state */
            //     typedef enum LEP_RAD_ENABLE_E_TAG { LEP_RAD_DISABLE = 0, LEP_RAD_ENABLE, LEP_END_RAD_ENABLE
            //     }LEP_RAD_ENABLE_E, *LEP_RAD_ENABLE_E_PTR;
            public void SetEnableStateChecked(Enable source);
            public void SetExternalRBFOHighGain(Rbfo source);
            public void SetExternalRBFOHighGainChecked(Rbfo source);
            //
            // Сводка:
            //     RAD Low Gain RBFO External Parameters
            //     These functions either get or set the radiometry low gain RBFO External parameters.
            //     The RBFO parameters define the equation for conversion between flux and temperature.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     R – 10000 – 1000000 – 64155 – Calibrated per camera – N/A – 1 –
            //     B – 1200000 – 1700000 – 1428000 – Calibrated per camera – N/A – 1000 –
            //     F – 500 – 3000 – 1000 – Calibrated per camera – N/A – 1000 –
            //     O – -16384000 – 16383000 – 728000 – Calibrated per camera – N/A – 1000 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0xD8
            //     With Set 0xD9
            //     SDK Data Length: Get 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Set 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadExternalRBFOLowGain() – Updates radRBFOPtr with the
            //     Camera’s current RBFO External parameters. –
            //     Lepton 2.5, 3.5 – LEP_SetRadExternalRBFOLowGain() – Updates the Camera’s RBFO
            //     External parameters with the contents of radRBFOPtr. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadExternalRBFOLowGain ( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RBFO_T_PTR radRBFOPtr ) LEP_RESULT LEP_SetRadExternalRBFOLowGain ( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RBFO_T_PTR radRBFOPtr ) /* RBFO */ typedef struct LEP_RBFO_T_TAG
            //     { // value is not scaled // value is scaled by X << n LEP_UINT32 RBFO_F; LEP_INT32
            //     RBFO_O; }LEP_RBFO_T, *LEP_RBFO_T_PTR;
            public void SetExternalRBFOLowGain(Rbfo source);
            //
            // Сводка:
            //     RAD Low Gain RBFO External Parameters
            //     These functions either get or set the radiometry low gain RBFO External parameters.
            //     The RBFO parameters define the equation for conversion between flux and temperature.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     R – 10000 – 1000000 – 64155 – Calibrated per camera – N/A – 1 –
            //     B – 1200000 – 1700000 – 1428000 – Calibrated per camera – N/A – 1000 –
            //     F – 500 – 3000 – 1000 – Calibrated per camera – N/A – 1000 –
            //     O – -16384000 – 16383000 – 728000 – Calibrated per camera – N/A – 1000 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0xD8
            //     With Set 0xD9
            //     SDK Data Length: Get 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Set 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadExternalRBFOLowGain() – Updates radRBFOPtr with the
            //     Camera’s current RBFO External parameters. –
            //     Lepton 2.5, 3.5 – LEP_SetRadExternalRBFOLowGain() – Updates the Camera’s RBFO
            //     External parameters with the contents of radRBFOPtr. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadExternalRBFOLowGain ( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RBFO_T_PTR radRBFOPtr ) LEP_RESULT LEP_SetRadExternalRBFOLowGain ( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RBFO_T_PTR radRBFOPtr ) /* RBFO */ typedef struct LEP_RBFO_T_TAG
            //     { // value is not scaled // value is scaled by X << n LEP_UINT32 RBFO_F; LEP_INT32
            //     RBFO_O; }LEP_RBFO_T, *LEP_RBFO_T_PTR;
            public void SetExternalRBFOLowGainChecked(Rbfo source);
            //
            // Сводка:
            //     RAD Flux Linear Parameters
            //     These functions either get or set various scene parameters used in the T-Linear
            //     calculations.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     sceneEmissivity – 82 – 8192 – 8192 – 8192 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TBkgK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     tauWindow – 82 – 8192 – 8192 – 8192 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TWindowK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     tauAtm – 82 – 8192 – 8192 – 8192 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TAtmK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     reflWindow – 0 – 8192–tauWindow – 0 – 0 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TReflK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xBD
            //     SDK Data Length: Get 8 size of LEP_RAD_FLUX_LINEAR_PARAMS_T data type
            //     Set 8 size of LEP_RAD_FLUX_LINEAR_PARAMS_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadFluxLinearParams() – Updates fluxParamsPtr with the
            //     camera’s Radiometry scene parameters used for T-Linear calculation. –
            //     Lepton 2.5, 3.5 – LEP_SetRadFluxLinearParams() – Updates the Camera’s current
            //     Radiometry scene parameters with the contents of fluxParams. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadFluxLinearParams (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_FLUX_LINEAR_PARAMS_T_PTR fluxParamsPtr) LEP_RESULT LEP_SetRadFluxLinearParams
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_FLUX_LINEAR_PARAMS_T fluxParams)
            //     /* Radiometry Flux Linear Params */ typedef struct LEP_RAD_FLUX_LINEAR_PARAMS_T_TAG
            //     { /* Type Field name format comment */ /* 3.13 */ /* 16.0 value in Kelvin 100x
            //     */ /* 3.13 */ /* 16.0 value in Kelvin 100x */ /* 3.13 */ /* 16.0 value in Kelvin
            //     100x */ /* 3.13 */ /* 16.0 value in Kelvin 100x */ }LEP_RAD_FLUX_LINEAR_PARAMS_T,
            //     *LEP_RAD_FLUX_LINEAR_PARAMS_T_PTR;
            public void SetFluxLinearParams(FluxLinearParams source);
            //
            // Сводка:
            //     RAD Flux Linear Parameters
            //     These functions either get or set various scene parameters used in the T-Linear
            //     calculations.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     sceneEmissivity – 82 – 8192 – 8192 – 8192 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TBkgK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     tauWindow – 82 – 8192 – 8192 – 8192 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TWindowK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     tauAtm – 82 – 8192 – 8192 – 8192 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TAtmK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     reflWindow – 0 – 8192–tauWindow – 0 – 0 – Percent –
            //     8192/100
            //     (8192 = 100%)
            //     –
            //     TReflK – 0 – 65535 – 30000 – 29515 – Kelvin –
            //     100
            //     (29515 = 295.15K)
            //     –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xBD
            //     SDK Data Length: Get 8 size of LEP_RAD_FLUX_LINEAR_PARAMS_T data type
            //     Set 8 size of LEP_RAD_FLUX_LINEAR_PARAMS_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadFluxLinearParams() – Updates fluxParamsPtr with the
            //     camera’s Radiometry scene parameters used for T-Linear calculation. –
            //     Lepton 2.5, 3.5 – LEP_SetRadFluxLinearParams() – Updates the Camera’s current
            //     Radiometry scene parameters with the contents of fluxParams. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadFluxLinearParams (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_FLUX_LINEAR_PARAMS_T_PTR fluxParamsPtr) LEP_RESULT LEP_SetRadFluxLinearParams
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_FLUX_LINEAR_PARAMS_T fluxParams)
            //     /* Radiometry Flux Linear Params */ typedef struct LEP_RAD_FLUX_LINEAR_PARAMS_T_TAG
            //     { /* Type Field name format comment */ /* 3.13 */ /* 16.0 value in Kelvin 100x
            //     */ /* 3.13 */ /* 16.0 value in Kelvin 100x */ /* 3.13 */ /* 16.0 value in Kelvin
            //     100x */ /* 3.13 */ /* 16.0 value in Kelvin 100x */ }LEP_RAD_FLUX_LINEAR_PARAMS_T,
            //     *LEP_RAD_FLUX_LINEAR_PARAMS_T_PTR;
            public void SetFluxLinearParamsChecked(FluxLinearParams source);
            public void SetFNumber(ushort source);
            public void SetFNumberChecked(ushort source);
            public void SetGlobalGain(ushort source);
            public void SetGlobalGainChecked(ushort source);
            public void SetGlobalOffset(ushort source);
            public void SetGlobalOffsetChecked(ushort source);
            public void SetHousingTcp(LinearTempCorrection source);
            public void SetHousingTcpChecked(LinearTempCorrection source);
            public void SetInternalRBFOHighGain(Rbfo source);
            public void SetInternalRBFOHighGainChecked(Rbfo source);
            public void SetInternalRBFOLowGain(Rbfo source);
            public void SetInternalRBFOLowGainChecked(Rbfo source);
            public void SetLensTcp(LinearTempCorrection source);
            public void SetLensTcpChecked(LinearTempCorrection source);
            public void SetMffcFlux(int source);
            public void SetMffcFluxChecked(int source);
            public void SetMLGLut(SignedLut128 source);
            public void SetMLGLutChecked(SignedLut128 source);
            public void SetRadioCalValues(RadioCalValues source);
            public void SetRadioCalValuesChecked(RadioCalValues source);
            public void SetRadometryFilter(ushort source);
            public void SetRadometryFilterChecked(ushort source);
            //
            // Сводка:
            //     RAD RBFO External Parameters
            //     This function gets and sets the radiometry RBFO External parameters. The RBFO
            //     parameters define the equation for conversion between flux and temperature.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     R – 10000 – 1000000 – 395653 – Calibrated per camera – N/A – 1 –
            //     B – 1200000 – 1700000 – 1428000 – Calibrated per camera – N/A – 1000 –
            //     F – 500 – 3000 – 1000 – Calibrated per camera – N/A – 1000 –
            //     O – -16384000 – 16383000 – 156000 – Calibrated per camera – N/A – 1000 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x04
            //     With Set 0x05
            //     SDK Data Length: Get 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Set 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadRBFOExternal0() – Updates radRBFOPtr with
            //     the Camera’s current RBFO External parameters. –
            //     All Lepton Configurations – LEP_SetRadRBFOExternal0() – Updates the Camera’s
            //     RBFO External parameters with the contents of radRBFOPtr. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadRBFOExternal0( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RBFO_T_PTR
            //     radRBFOPtr ) LEP_RESULT LEP_SetRadRBFOExternal0( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RBFO_T_PTR radRBFOPtr ) /* RBFO */ typedef struct LEP_RBFO_T_TAG { // value
            //     is not scaled // value is scaled by X << n LEP_UINT32 RBFO_F; LEP_INT32 RBFO_O;
            //     }LEP_RBFO_T, *LEP_RBFO_T_PTR;
            public void SetRBFOExternal0(Rbfo source);
            //
            // Сводка:
            //     RAD RBFO External Parameters
            //     This function gets and sets the radiometry RBFO External parameters. The RBFO
            //     parameters define the equation for conversion between flux and temperature.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     R – 10000 – 1000000 – 395653 – Calibrated per camera – N/A – 1 –
            //     B – 1200000 – 1700000 – 1428000 – Calibrated per camera – N/A – 1000 –
            //     F – 500 – 3000 – 1000 – Calibrated per camera – N/A – 1000 –
            //     O – -16384000 – 16383000 – 156000 – Calibrated per camera – N/A – 1000 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x04
            //     With Set 0x05
            //     SDK Data Length: Get 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Set 8 size of a LEP_RBFO_T data type, 4 x 2 words each
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadRBFOExternal0() – Updates radRBFOPtr with
            //     the Camera’s current RBFO External parameters. –
            //     All Lepton Configurations – LEP_SetRadRBFOExternal0() – Updates the Camera’s
            //     RBFO External parameters with the contents of radRBFOPtr. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadRBFOExternal0( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RBFO_T_PTR
            //     radRBFOPtr ) LEP_RESULT LEP_SetRadRBFOExternal0( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RBFO_T_PTR radRBFOPtr ) /* RBFO */ typedef struct LEP_RBFO_T_TAG { // value
            //     is not scaled // value is scaled by X << n LEP_UINT32 RBFO_F; LEP_INT32 RBFO_O;
            //     }LEP_RBFO_T, *LEP_RBFO_T_PTR;
            public void SetRBFOExternal0Checked(Rbfo source);
            public void SetRBFOInternal0(Rbfo source);
            public void SetRBFOInternal0Checked(Rbfo source);
            public void SetResponsivityShift(ushort source);
            public void SetResponsivityShiftChecked(ushort source);
            public void SetResponsivityValueLut(Lut128 source);
            public void SetResponsivityValueLutChecked(Lut128 source);
            public void SetShutterTcp(LinearTempCorrection source);
            public void SetShutterTcpChecked(LinearTempCorrection source);
            //
            // Сводка:
            //     RAD Spotmeter Region of Interest (ROI)
            //     These functions either get or set a rectangular region of interest within the
            //     video frame extents which RAD operations can use to calculate temperature measurement
            //     minimum, maximum, and average.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column-1 – 39 – pixels – 1 –
            //     start row
            //     – 0 – < end row-1 – 29 – pixels – 1 –
            //     end column
            //     – > start column+1 – 79 – 40 – pixels – 1 –
            //     end row
            //     – > start row+1 – 59 – 30 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column-1 – 79 – pixels – 1 –
            //     start row
            //     – 0 – < end row-1 – 59 – pixels – 1 –
            //     end column
            //     – > start column+1 – 159 – 80 – pixels – 1 –
            //     end row
            //     – > start row+1 – 119 – 60 – pixels – 1 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xCD
            //     SDK Data Length: Get 4 size of LEP_RAD_ROI_T data type
            //     Set 4 size of LEP_RAD_ROI_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadSpotmeterRoi() – Updates spotmeterRoiPtr with the
            //     camera’s current spotmeter ROI. –
            //     Lepton 2.5, 3.5 – LEP_SetRadSpotmeterRoi() – Updates the Camera’s current spotmeter
            //     ROI with the contents of spotmeterRoi. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadSpotmeterRoi (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ROI_T_PTR
            //     spotmeterRoiPtr) LEP_RESULT LEP_SetRadSpotmeterRoi (LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RAD_ROI_T spotmeterRoi) /* Radiometry ROI */ typedef struct
            //     LEP_RAD_ROI_T_TAG { LEP_UINT16 startRow; LEP_UINT16 startCol; LEP_UINT16 endRow;
            //     LEP_UINT16 endCol; }LEP_RAD_ROI_T, *LEP_RAD_ROI_T_PTR;
            public void SetSpotmeterRoi(Roi source);
            //
            // Сводка:
            //     RAD Spotmeter Region of Interest (ROI)
            //     These functions either get or set a rectangular region of interest within the
            //     video frame extents which RAD operations can use to calculate temperature measurement
            //     minimum, maximum, and average.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column-1 – 39 – pixels – 1 –
            //     start row
            //     – 0 – < end row-1 – 29 – pixels – 1 –
            //     end column
            //     – > start column+1 – 79 – 40 – pixels – 1 –
            //     end row
            //     – > start row+1 – 59 – 30 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column-1 – 79 – pixels – 1 –
            //     start row
            //     – 0 – < end row-1 – 59 – pixels – 1 –
            //     end column
            //     – > start column+1 – 159 – 80 – pixels – 1 –
            //     end row
            //     – > start row+1 – 119 – 60 – pixels – 1 –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xCD
            //     SDK Data Length: Get 4 size of LEP_RAD_ROI_T data type
            //     Set 4 size of LEP_RAD_ROI_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadSpotmeterRoi() – Updates spotmeterRoiPtr with the
            //     camera’s current spotmeter ROI. –
            //     Lepton 2.5, 3.5 – LEP_SetRadSpotmeterRoi() – Updates the Camera’s current spotmeter
            //     ROI with the contents of spotmeterRoi. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadSpotmeterRoi (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ROI_T_PTR
            //     spotmeterRoiPtr) LEP_RESULT LEP_SetRadSpotmeterRoi (LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RAD_ROI_T spotmeterRoi) /* Radiometry ROI */ typedef struct
            //     LEP_RAD_ROI_T_TAG { LEP_UINT16 startRow; LEP_UINT16 startCol; LEP_UINT16 endRow;
            //     LEP_UINT16 endCol; }LEP_RAD_ROI_T, *LEP_RAD_ROI_T_PTR;
            public void SetSpotmeterRoiChecked(Roi source);
            public void SetTauLens(ushort source);
            public void SetTauLensChecked(ushort source);
            public void SetTAuxCLut(Lut256 source);
            public void SetTAuxCLutChecked(Lut256 source);
            public void SetTAuxCts(ushort source);
            public void SetTAuxCtsChecked(ushort source);
            public void SetTAuxCtsMode(TemperatureUpdate source);
            public void SetTAuxCtsModeChecked(TemperatureUpdate source);
            public void SetTAuxLut(Lut256 source);
            public void SetTAuxLutChecked(Lut256 source);
            public void SetTEqShutterFlux(int source);
            public void SetTEqShutterFluxChecked(int source);
            public void SetTEqShutterLut(Lut128 source);
            public void SetTEqShutterLutChecked(Lut128 source);
            public void SetTFpaCLut(Lut256 source);
            public void SetTFpaCLutChecked(Lut256 source);
            public void SetTFpaCts(ushort source);
            public void SetTFpaCtsChecked(ushort source);
            public void SetTFpaCtsMode(TemperatureUpdate source);
            public void SetTFpaCtsModeChecked(TemperatureUpdate source);
            public void SetTFpaLut(Lut256 source);
            public void SetTFpaLutChecked(Lut256 source);
            //
            // Сводка:
            //     RAD T-Linear Auto Resolution
            //     These functions either get or set the T-Linear automatic resolution enable state.
            //     When enabled, T-Linear output resolution is chosen automatically based on scene
            //     statistics and gain mode.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     enableState – LEP_RAD_DISABLE – LEP_RAD_ENABLE – LEP_RAD_DISABLE – N/A – N/A
            //     –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xC9
            //     SDK Data Length: Get 2 size of an Enum data type on a 32-bit machine
            //     Set 2 size of an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadTLinearAutoResolution() – Updates enableStatePtr
            //     with the camera’s T-Linear automatic resolution feature enable state. –
            //     Lepton 2.5, 3.5 – LEP_SetRadTLinearAutoResolution() – Updates the Camera’s current
            //     T-Linear automatic resolution feature with the contents of enableState. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTLinearAutoResolution (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_ENABLE_E_PTR enableStatePtr) LEP_RESULT LEP_SetRadTLinearAutoResolution
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ENABLE_E enableState) /* Radiometry
            //     Enable state */ typedef enum LEP_RAD_ENABLE_E_TAG { LEP_RAD_DISABLE = 0, LEP_RAD_ENABLE,
            //     LEP_END_RAD_ENABLE }LEP_RAD_ENABLE_E, *LEP_RAD_ENABLE_E_PTR;
            public void SetTLinearAutoResolution(Enable source);
            //
            // Сводка:
            //     RAD T-Linear Auto Resolution
            //     These functions either get or set the T-Linear automatic resolution enable state.
            //     When enabled, T-Linear output resolution is chosen automatically based on scene
            //     statistics and gain mode.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     enableState – LEP_RAD_DISABLE – LEP_RAD_ENABLE – LEP_RAD_DISABLE – N/A – N/A
            //     –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xC9
            //     SDK Data Length: Get 2 size of an Enum data type on a 32-bit machine
            //     Set 2 size of an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadTLinearAutoResolution() – Updates enableStatePtr
            //     with the camera’s T-Linear automatic resolution feature enable state. –
            //     Lepton 2.5, 3.5 – LEP_SetRadTLinearAutoResolution() – Updates the Camera’s current
            //     T-Linear automatic resolution feature with the contents of enableState. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTLinearAutoResolution (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_ENABLE_E_PTR enableStatePtr) LEP_RESULT LEP_SetRadTLinearAutoResolution
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ENABLE_E enableState) /* Radiometry
            //     Enable state */ typedef enum LEP_RAD_ENABLE_E_TAG { LEP_RAD_DISABLE = 0, LEP_RAD_ENABLE,
            //     LEP_END_RAD_ENABLE }LEP_RAD_ENABLE_E, *LEP_RAD_ENABLE_E_PTR;
            public void SetTLinearAutoResolutionChecked(Enable source);
            //
            // Сводка:
            //     RAD T-Linear Enable State
            //     These functions either get or set the T-Linear output enable state. When enabled,
            //     the video output represents temperature in Kelvin with some scale factor defined
            //     by the T-linear Resolution parameter. T-Linear mode requires radiometry mode
            //     (temperature stable output) to also be enabled.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     enableState – LEP_RAD_DISABLE – LEP_RAD_ENABLE – LEP_RAD_DISABLE – LEP_RAD_ENABLE
            //     – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xC1
            //     SDK Data Length: Get 2 size of an Enum data type on a 32-bit machine
            //     Set 2 size of an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadTLinearEnableState() – Updates enableStatePtr with
            //     the camera’s T-Linear calculation enable state. –
            //     Lepton 2.5, 3.5 – LEP_SetRadTLinearEnableState() – Updates the Camera’s current
            //     T-Linear calculation enable state with the contents of enableState. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTLinearEnableState (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_ENABLE_E_PTR enableStatePtr) LEP_RESULT LEP_SetRadTLinearEnableState
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ENABLE_E enableState) /* Radiometry
            //     Enable state */ typedef enum LEP_RAD_ENABLE_E_TAG { LEP_RAD_DISABLE = 0, LEP_RAD_ENABLE,
            //     LEP_END_RAD_ENABLE }LEP_RAD_ENABLE_E, *LEP_RAD_ENABLE_E_PTR;
            public void SetTLinearEnableState(Enable source);
            //
            // Сводка:
            //     RAD T-Linear Enable State
            //     These functions either get or set the T-Linear output enable state. When enabled,
            //     the video output represents temperature in Kelvin with some scale factor defined
            //     by the T-linear Resolution parameter. T-Linear mode requires radiometry mode
            //     (temperature stable output) to also be enabled.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default – Units – Scale factor –
            //     enableState – LEP_RAD_DISABLE – LEP_RAD_ENABLE – LEP_RAD_DISABLE – LEP_RAD_ENABLE
            //     – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xC1
            //     SDK Data Length: Get 2 size of an Enum data type on a 32-bit machine
            //     Set 2 size of an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadTLinearEnableState() – Updates enableStatePtr with
            //     the camera’s T-Linear calculation enable state. –
            //     Lepton 2.5, 3.5 – LEP_SetRadTLinearEnableState() – Updates the Camera’s current
            //     T-Linear calculation enable state with the contents of enableState. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTLinearEnableState (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_ENABLE_E_PTR enableStatePtr) LEP_RESULT LEP_SetRadTLinearEnableState
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_ENABLE_E enableState) /* Radiometry
            //     Enable state */ typedef enum LEP_RAD_ENABLE_E_TAG { LEP_RAD_DISABLE = 0, LEP_RAD_ENABLE,
            //     LEP_END_RAD_ENABLE }LEP_RAD_ENABLE_E, *LEP_RAD_ENABLE_E_PTR;
            public void SetTLinearEnableStateChecked(Enable source);
            //
            // Сводка:
            //     RAD T-Linear Resolution
            //     These functions either get or set the T-Linear output resolution, which defines
            //     the scale factor for the temperature measurements contained in the video output
            //     (per-pixel) with T-Linear mode enabled.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default –
            //     resolution – LEP_RAD_RESOLUTION_0_1 – LEP_RAD_RESOLUTION_0_01 – LEP_RAD_RESOLUTION_0_1
            //     – LEP_RAD_RESOLUTION_0_01 –
            //     Setting – Minimum Pixel Value – Maximum Pixel Value – Units – Scale factor –
            //     LEP_RAD_RESOLUTION_0_1 – 0 – 65535 – Kelvin –
            //     10
            //     (65535 = 6553.5K)
            //     –
            //     LEP_RAD_RESOLUTION_0_01 – 0 – 65535 – Kelvin –
            //     100
            //     (65535 = 655.35K)
            //     –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xC5
            //     SDK Data Length: Get 2 size of an Enum data type on a 32-bit machine
            //     Set 2 size of an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadTLinearResolution() – Updates resolutionPtr with
            //     the camera’s T-Linear calculation resolution. –
            //     Lepton 2.5, 3.5 – LEP_SetRadTLinearResolution() – Updates the Camera’s current
            //     T-Linear calculation resolution with the contents of resolution. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTLinearResolution (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_TLINEAR_RESOLUTION_E_PTR resolutionPtr) LEP_RESULT LEP_SetRadTLinearResolution
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_TLINEAR_RESOLUTION_E resolution)
            //     /* Radiometry T-Linear Resolution */ typedef enum LEP_RAD_TLINEAR_RESOLUTION_E_TAG
            //     { LEP_RAD_RESOLUTION_0_1 = 0, LEP_RAD_RESOLUTION_0_01, LEP_RAD_END_RESOLUTION
            //     }LEP_RAD_TLINEAR_RESOLUTION_E, *LEP_RAD_TLINEAR_RESOLUTION_E_PTR;
            public void SetTLinearResolution(TlinearResolution source);
            //
            // Сводка:
            //     RAD T-Linear Resolution
            //     These functions either get or set the T-Linear output resolution, which defines
            //     the scale factor for the temperature measurements contained in the video output
            //     (per-pixel) with T-Linear mode enabled.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Radiometric Releases Factory
            //     Default –
            //     resolution – LEP_RAD_RESOLUTION_0_1 – LEP_RAD_RESOLUTION_0_01 – LEP_RAD_RESOLUTION_0_1
            //     – LEP_RAD_RESOLUTION_0_01 –
            //     Setting – Minimum Pixel Value – Maximum Pixel Value – Units – Scale factor –
            //     LEP_RAD_RESOLUTION_0_1 – 0 – 65535 – Kelvin –
            //     10
            //     (65535 = 6553.5K)
            //     –
            //     LEP_RAD_RESOLUTION_0_01 – 0 – 65535 – Kelvin –
            //     100
            //     (65535 = 655.35K)
            //     –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get With Set 0xC5
            //     SDK Data Length: Get 2 size of an Enum data type on a 32-bit machine
            //     Set 2 size of an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetRadTLinearResolution() – Updates resolutionPtr with
            //     the camera’s T-Linear calculation resolution. –
            //     Lepton 2.5, 3.5 – LEP_SetRadTLinearResolution() – Updates the Camera’s current
            //     T-Linear calculation resolution with the contents of resolution. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTLinearResolution (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_TLINEAR_RESOLUTION_E_PTR resolutionPtr) LEP_RESULT LEP_SetRadTLinearResolution
            //     (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_TLINEAR_RESOLUTION_E resolution)
            //     /* Radiometry T-Linear Resolution */ typedef enum LEP_RAD_TLINEAR_RESOLUTION_E_TAG
            //     { LEP_RAD_RESOLUTION_0_1 = 0, LEP_RAD_RESOLUTION_0_01, LEP_RAD_END_RESOLUTION
            //     }LEP_RAD_TLINEAR_RESOLUTION_E, *LEP_RAD_TLINEAR_RESOLUTION_E_PTR;
            public void SetTLinearResolutionChecked(TlinearResolution source);
            //
            // Сводка:
            //     RAD TShutter Temperature
            //     This function gets or sets the TShutter temperature. The TShutter temperature
            //     is used at FFC when the TShutter Mode is “User”.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     radTShutter – 0 – 65535 – 30000 – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x28
            //     With Set 0x29
            //     SDK Data Length: Get 1 size of LEP_RAD_KELVIN_T data type
            //     Set 1 size of LEP_RAD_KELVIN_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadTShutter() – Updates radTShutterPtr with
            //     current TShutter temperature –
            //     All Lepton Configurations – LEP_SetRadTShutter() – Updates the Camera’s current
            //     TShutter temperature with the contents of radTShutter. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTShutter( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_KELVIN_T_PTR
            //     radTShutterPtr ) LEP_RESULT LEP_SetRadTShutter( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_KELVIN_T radTShutter ) /* TShutter value is 100xKelvin [16.0] */ typedef
            //     LEP_UINT16 LEP_RAD_KELVIN_T, *LEP_RAD_KELVIN_T_PTR;
            public void SetTShutter(ushort source);
            //
            // Сводка:
            //     RAD TShutter Temperature
            //     This function gets or sets the TShutter temperature. The TShutter temperature
            //     is used at FFC when the TShutter Mode is “User”.
            //
            // Примечания:
            //      – Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     radTShutter – 0 – 65535 – 30000 – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x28
            //     With Set 0x29
            //     SDK Data Length: Get 1 size of LEP_RAD_KELVIN_T data type
            //     Set 1 size of LEP_RAD_KELVIN_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadTShutter() – Updates radTShutterPtr with
            //     current TShutter temperature –
            //     All Lepton Configurations – LEP_SetRadTShutter() – Updates the Camera’s current
            //     TShutter temperature with the contents of radTShutter. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTShutter( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_KELVIN_T_PTR
            //     radTShutterPtr ) LEP_RESULT LEP_SetRadTShutter( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_RAD_KELVIN_T radTShutter ) /* TShutter value is 100xKelvin [16.0] */ typedef
            //     LEP_UINT16 LEP_RAD_KELVIN_T, *LEP_RAD_KELVIN_T_PTR;
            public void SetTShutterChecked(ushort source);
            //
            // Сводка:
            //     RAD TShutter Mode
            //     This function gets or sets the TShutter mode. The TShutter mode specifies how
            //     TShutter value is obtained at FFC.
            //
            // Примечания:
            //     User: Use the TShutter value set with LEP_SetRadTShutter()
            //     Cal: Use TEqShutter from calibration
            //     Fixed: the shutter temperature is considered static, and therefore the spotmeter
            //     is not updated at FFC
            //     – Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     radTShutterMode – FLR_RAD_TS_USER_MODE – FLR_RAD_TS_FIXED_MODE – FLR_RAD_TS_CAL_MODE
            //     – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadTShutterMode() – Updates radTShutterModePtr
            //     with current TShutter mode –
            //     All Lepton Configurations – LEP_SetRadTShutterMode() – Updates the Camera’s current
            //     TShutter mode with the contents of radTShutterMode. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTShutterMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_TS_MODE_E_PTR
            //     radTShutterModePtr ) LEP_RESULT LEP_SetRadTShutterMode( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RAD_TS_MODE_E radTShutterMode ) /* TShutter Modes */ typedef
            //     enum FLR_RAD_TS_MODE_E_TAG { FLR_RAD_TS_USER_MODE = 0, FLR_RAD_TS_CAL_MODE, FLR_RAD_TS_FIXED_MODE,
            //     FLR_RAD_TS_END_TS_MODE }FLR_RAD_TS_MODE_E, *FLR_RAD_TS_MODE_E_PTR;
            public void SetTShutterMode(TsMode source);
            //
            // Сводка:
            //     RAD TShutter Mode
            //     This function gets or sets the TShutter mode. The TShutter mode specifies how
            //     TShutter value is obtained at FFC.
            //
            // Примечания:
            //     User: Use the TShutter value set with LEP_SetRadTShutter()
            //     Cal: Use TEqShutter from calibration
            //     Fixed: the shutter temperature is considered static, and therefore the spotmeter
            //     is not updated at FFC
            //     – Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     radTShutterMode – FLR_RAD_TS_USER_MODE – FLR_RAD_TS_FIXED_MODE – FLR_RAD_TS_CAL_MODE
            //     – N/A – N/A –
            //     SDK Module ID: RAD 0x0E00
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetRadTShutterMode() – Updates radTShutterModePtr
            //     with current TShutter mode –
            //     All Lepton Configurations – LEP_SetRadTShutterMode() – Updates the Camera’s current
            //     TShutter mode with the contents of radTShutterMode. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetRadTShutterMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_RAD_TS_MODE_E_PTR
            //     radTShutterModePtr ) LEP_RESULT LEP_SetRadTShutterMode( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_RAD_TS_MODE_E radTShutterMode ) /* TShutter Modes */ typedef
            //     enum FLR_RAD_TS_MODE_E_TAG { FLR_RAD_TS_USER_MODE = 0, FLR_RAD_TS_CAL_MODE, FLR_RAD_TS_FIXED_MODE,
            //     FLR_RAD_TS_END_TS_MODE }FLR_RAD_TS_MODE_E, *FLR_RAD_TS_MODE_E_PTR;
            public void SetTShutterModeChecked(TsMode source);

            public enum TsMode
            {
                TS_USER_MODE = 0,
                TS_CAL_MODE = 1,
                TS_FIXED_MODE = 2
            }
            public enum Enable
            {
                DISABLE = 0,
                ENABLE = 1
            }
            public enum TemperatureUpdate
            {
                NORMAL_UPDATE = 0,
                NO_UPDATE = 1
            }
            public enum Status
            {
                STATUS_ERROR = -1,
                STATUS_READY = 0,
                STATUS_BUSY = 1,
                FRAME_AVERAGE_COLLECTING_FRAMES = 2
            }
            public enum TlinearResolution
            {
                RESOLUTION_0_1 = 0,
                RESOLUTION_0_01 = 1
            }
            public enum ArbitraryOffsetMode
            {
                MANUAL = 0,
                AUTO = 1
            }

            public class ArbitraryOffsetParams
            {
                public short amplitude;
                public ushort decay;

                public ArbitraryOffsetParams(short amplitude, ushort decay);

                public override string ToString();
            }
            public class Roi
            {
                public ushort startRow;
                public ushort startCol;
                public ushort endRow;
                public ushort endCol;

                public Roi(ushort startRow, ushort startCol, ushort endRow, ushort endCol);

                public override string ToString();
            }
            public class FluxLinearParams
            {
                public ushort sceneEmissivity;
                public ushort TBkgK;
                public ushort tauWindow;
                public ushort TWindowK;
                public ushort tauAtm;
                public ushort TAtmK;
                public ushort reflWindow;
                public ushort TReflK;

                public FluxLinearParams(ushort sceneEmissivity, ushort TBkgK, ushort tauWindow, ushort TWindowK, ushort tauAtm, ushort TAtmK, ushort reflWindow, ushort TReflK);

                public override string ToString();
            }
            public class LinearTempCorrection
            {
                public short offset;
                public short gainAux;
                public short gainShutter;
                public ushort pad;

                public LinearTempCorrection(short offset, short gainAux, short gainShutter, ushort pad);

                public override string ToString();
            }
            public class SignedLut128
            {
                public ushort[] value;

                public SignedLut128(ushort[] value);

                public override string ToString();
            }
            public class Lut256
            {
                public ushort[] value;

                public Lut256(ushort[] value);

                public override string ToString();
            }
            public class Lut128
            {
                public ushort[] value;

                public Lut128(ushort[] value);

                public override string ToString();
            }
            public class SpotmeterObjKelvin
            {
                public ushort radSpotmeterValue;
                public ushort radSpotmeterMaxValue;
                public ushort radSpotmeterMinValue;
                public ushort radSpotmeterPopulation;

                public SpotmeterObjKelvin(ushort radSpotmeterValue, ushort radSpotmeterMaxValue, ushort radSpotmeterMinValue, ushort radSpotmeterPopulation);

                public override string ToString();
            }
            public class Rbfo
            {
                public uint RBFO_R;
                public uint RBFO_B;
                public uint RBFO_F;
                public int RBFO_O;

                public Rbfo(uint RBFO_R, uint RBFO_B, uint RBFO_F, int RBFO_O);

                public override string ToString();
            }
            public class RadioCalValues
            {
                public ushort radTauxCounts;
                public ushort radTfpaCounts;
                public ushort radTauxKelvin;
                public ushort radTfpaKelvin;

                public RadioCalValues(ushort radTauxCounts, ushort radTfpaCounts, ushort radTauxKelvin, ushort radTfpaKelvin);

                public override string ToString();
            }
        }
        public class LepTimeoutError : LepCommError
        {
            public LepTimeoutError();
        }
        public class LepErrorI2cFail : LepErrorI2c
        {
            public LepErrorI2cFail();
        }
        public class LepErrorI2cBufferOverflow : LepErrorI2c
        {
            public LepErrorI2cBufferOverflow();
        }
        public class LepErrorI2cBusError : LepErrorI2c
        {
            public LepErrorI2cBusError();
        }
        public class Error : Exception
        {
            public Error();
        }
        public class LepError : Error
        {
            public LepError();

            public static LepError FromCode(int code);
            public static LepError FromCode(Result code);
        }
        public class LepNotReady : LepError
        {
            public LepNotReady();
        }
        public class LepRangeError : LepError
        {
            public LepRangeError();
        }
        public class LepChecksumError : LepError
        {
            public LepChecksumError();
        }
        public class LepBadArgPointerError : LepError
        {
            public LepBadArgPointerError();
        }
        public class LepDataSizeError : LepError
        {
            public LepDataSizeError();
        }
        public class LepUndefinedFunctionError : LepError
        {
            public LepUndefinedFunctionError();
        }
        public class LepFunctionNotSupported : LepError
        {
            public LepFunctionNotSupported();
        }
        public class LepDataOutOfRangeError : LepError
        {
            public LepDataOutOfRangeError();
        }
        public class LepCommandNotAllowed : LepError
        {
            public LepCommandNotAllowed();
        }
        public class LepOperationCanceled : LepError
        {
            public LepOperationCanceled();
        }
        public class LepUndefinedErrorCode : LepError
        {
            public LepUndefinedErrorCode();
        }
        public class LepOtpError : LepError
        {
            public LepOtpError();
        }
        public class LepOtpWriteError : LepOtpError
        {
            public LepOtpWriteError();
        }
        public class LepOtpReadError : LepOtpError
        {
            public LepOtpReadError();
        }
        public class LepOtpNotProgrammedError : LepOtpError
        {
            public LepOtpNotProgrammedError();
        }
        public class LepErrorI2c : LepError
        {
            public LepErrorI2c();
        }
        public class LepErrorI2cBusNotReady : LepErrorI2c
        {
            public LepErrorI2cBusNotReady();
        }
        //
        // Сводка:
        //     This module provides information and status of the camera system. This includes
        //     the camera serial number, current camera status, a method to ping the camera
        //     to verify communication, and Telemetry row enable and location control.
        public class Sys
        {
            public Sys(UVC port);

            //
            // Сводка:
            //     SYS AUX Temperature Celsius – helper function
            //     This is a SDK command that returns the Lepton Camera’s AUX Temperature in degrees
            //     Celsius. This function has no command ID since it is a helper function and uses
            //     the function LEP_GetSysAuxTemperatureKelvin()to get the current temperature in
            //     Kelvin before converting to degrees Celsius.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Units – Scale factor –
            //     - – - – Degrees Celsius – N/A (float value) –
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysAuxTemperatureCelsius() – Returns the Lepton
            //     Camera’s AUX Temperature in degrees Celsius –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysAuxTemperatureCelsius( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_AUX_TEMPERATURE_CELSIUS_T_PTR auxTemperaturePtr ) typedef LEP_FLOAT32
            //     LEP_SYS_AUX_TEMPERATURE_CELSIUS_T, *LEP_SYS_AUX_TEMPERATURE_CELSIUS_T_PTR;
            public float GetAuxTemperatureCelsius();
            //
            // Сводка:
            //     SYS AUX Temperature Celsius – helper function
            //     This is a SDK command that returns the Lepton Camera’s AUX Temperature in degrees
            //     Celsius. This function has no command ID since it is a helper function and uses
            //     the function LEP_GetSysAuxTemperatureKelvin()to get the current temperature in
            //     Kelvin before converting to degrees Celsius.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Units – Scale factor –
            //     - – - – Degrees Celsius – N/A (float value) –
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysAuxTemperatureCelsius() – Returns the Lepton
            //     Camera’s AUX Temperature in degrees Celsius –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysAuxTemperatureCelsius( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_AUX_TEMPERATURE_CELSIUS_T_PTR auxTemperaturePtr ) typedef LEP_FLOAT32
            //     LEP_SYS_AUX_TEMPERATURE_CELSIUS_T, *LEP_SYS_AUX_TEMPERATURE_CELSIUS_T_PTR;
            public float GetAuxTemperatureCelsiusChecked();
            //
            // Сводка:
            //     SYS AUX Temperature Kelvin
            //     This command returns the Lepton Camera’s AUX Temperature in Kelvin.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Units – Scale factor –
            //     0 – 16383 – Kelvin – 100 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x10
            //     SDK Data Length: Get 1 size of the LEP_SYS_AUX_TEMPERATURE_KELVIN_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetSysAuxTemperatureKelvin() – Returns the Lepton Camera’s
            //     AUX Temperature in Kelvin –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysAuxTemperatureKelvin(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_AUX_TEMPERATURE_KELVIN_T_PTR auxTemperaturePtr); typedef LEP_UINT16 LEP_SYS_AUX_TEMPERATURE_KELVIN_T,
            //     *LEP_SYS_AUX_TEMPERATURE_KELVIN_T_PTR;
            public ushort GetAuxTemperatureKelvin();
            //
            // Сводка:
            //     SYS AUX Temperature Kelvin
            //     This command returns the Lepton Camera’s AUX Temperature in Kelvin.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Units – Scale factor –
            //     0 – 16383 – Kelvin – 100 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x10
            //     SDK Data Length: Get 1 size of the LEP_SYS_AUX_TEMPERATURE_KELVIN_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetSysAuxTemperatureKelvin() – Returns the Lepton Camera’s
            //     AUX Temperature in Kelvin –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysAuxTemperatureKelvin(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_AUX_TEMPERATURE_KELVIN_T_PTR auxTemperaturePtr); typedef LEP_UINT16 LEP_SYS_AUX_TEMPERATURE_KELVIN_T,
            //     *LEP_SYS_AUX_TEMPERATURE_KELVIN_T_PTR;
            public ushort GetAuxTemperatureKelvinChecked();
            public BoresightValues GetBoresightValues();
            public BoresightValues GetBoresightValuesChecked();
            //
            // Сводка:
            //     SYS Camera Uptime
            //     This command returns the Lepton Camera’s current uptime in milliseconds. The
            //     uptime is the time since the camera was brought out of Standby. The uptime counter
            //     is implemented as a 32-bit counter and as such will roll-over after the maximum
            //     count of 0xFFFFFFFF (1193 hours) is reached and restart at 0x00000000.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 4294967295 – N/A – milliseconds – 1 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x0C
            //     SDK Data Length: Get 2 size of the LEP_UINT32 data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysCameraUpTime() – Updates sysCameraUpTimePtr
            //     with the Camera’s current uptime in milliseconds –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysCameraUpTime(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_UINT32
            //     *sysCameraUpTimePtr)
            public uint GetCameraUpTime();
            //
            // Сводка:
            //     SYS Camera Uptime
            //     This command returns the Lepton Camera’s current uptime in milliseconds. The
            //     uptime is the time since the camera was brought out of Standby. The uptime counter
            //     is implemented as a 32-bit counter and as such will roll-over after the maximum
            //     count of 0xFFFFFFFF (1193 hours) is reached and restart at 0x00000000.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 4294967295 – N/A – milliseconds – 1 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x0C
            //     SDK Data Length: Get 2 size of the LEP_UINT32 data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysCameraUpTime() – Updates sysCameraUpTimePtr
            //     with the Camera’s current uptime in milliseconds –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysCameraUpTime(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_UINT32
            //     *sysCameraUpTimePtr)
            public uint GetCameraUpTimeChecked();
            //
            // Сводка:
            //     SYS Camera Customer Serial Number
            //     This command returns the Lepton Camera’s Customer serial number as a 32-byte
            //     character string. The Customer Serial Number is a (32 byte string) identifier
            //     unique to a specific configuration of module; essentially a module Configuration
            //     ID. This serial number is unwritten in the current release.
            //     This command requires the Host to allocate the memory buffer before calling this
            //     function. The address to this memory block should be passed in as sysSerialNumberPtr
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x28
            //     SDK Data Length: Get 16 32-byte string Data type
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysCustSerialNumber() – Updates sysSerialNumberPtr
            //     with the Camera’s 32-byte serial number. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysCustSerialNumber( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_CUST_SERIAL_NUMBER_T_PTR sysSerialNumberPtr ) typedef LEP_CHAR8 *LEP_SYS_CUST_SERIAL_NUMBER_T,
            //     *LEP_SYS_CUST_SERIAL_NUMBER_T_PTR;
            public CustSerialNumber GetCustSerialNumber();
            //
            // Сводка:
            //     SYS Camera Customer Serial Number
            //     This command returns the Lepton Camera’s Customer serial number as a 32-byte
            //     character string. The Customer Serial Number is a (32 byte string) identifier
            //     unique to a specific configuration of module; essentially a module Configuration
            //     ID. This serial number is unwritten in the current release.
            //     This command requires the Host to allocate the memory buffer before calling this
            //     function. The address to this memory block should be passed in as sysSerialNumberPtr
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x28
            //     SDK Data Length: Get 16 32-byte string Data type
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysCustSerialNumber() – Updates sysSerialNumberPtr
            //     with the Camera’s 32-byte serial number. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysCustSerialNumber( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_CUST_SERIAL_NUMBER_T_PTR sysSerialNumberPtr ) typedef LEP_CHAR8 *LEP_SYS_CUST_SERIAL_NUMBER_T,
            //     *LEP_SYS_CUST_SERIAL_NUMBER_T_PTR;
            public CustSerialNumber GetCustSerialNumberChecked();
            public FfcShutterModeObj GetFfcShutterModeObj();
            public FfcShutterModeObj GetFfcShutterModeObjChecked();
            //
            // Сводка:
            //     SYS FFC States
            //     This command gets the current FFC state in the camera.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_SYS_FFC_NEVER_COMMANDED – LEP_SYS_FFC_IN_PROCESS – LEP_SYS_FFC_NEVER_COMMANDED
            //     – N/A – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x4D
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetSysFFCStates() – Returns the Lepton Camera’s current
            //     FFC state ffcStatePtr –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysFFCStates( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_FFC_STATES_E_PTR
            //     ffcStatePtr ) /* SYS FFC States Enum Captures the current camera FFC operation
            //     state */ typedef enum LEP_SYS_FFC_STATES_E_TAG { LEP_SYS_FFC_NEVER_COMMANDED
            //     = 0, LEP_SYS_FFC_IMMINENT, LEP_SYS_FFC_IN_PROCESS, LEP_SYS_FFC_DONE, LEP_SYS_END_FFC_STATES
            //     }LEP_SYS_FFC_STATES_E, *LEP_SYS_FFC_STATES_E_PTR;
            public FfcStates GetFFCStates();
            //
            // Сводка:
            //     SYS FFC States
            //     This command gets the current FFC state in the camera.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_SYS_FFC_NEVER_COMMANDED – LEP_SYS_FFC_IN_PROCESS – LEP_SYS_FFC_NEVER_COMMANDED
            //     – N/A – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x4D
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetSysFFCStates() – Returns the Lepton Camera’s current
            //     FFC state ffcStatePtr –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysFFCStates( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_FFC_STATES_E_PTR
            //     ffcStatePtr ) /* SYS FFC States Enum Captures the current camera FFC operation
            //     state */ typedef enum LEP_SYS_FFC_STATES_E_TAG { LEP_SYS_FFC_NEVER_COMMANDED
            //     = 0, LEP_SYS_FFC_IMMINENT, LEP_SYS_FFC_IN_PROCESS, LEP_SYS_FFC_DONE, LEP_SYS_END_FFC_STATES
            //     }LEP_SYS_FFC_STATES_E, *LEP_SYS_FFC_STATES_E_PTR;
            public FfcStates GetFFCStatesChecked();
            //
            // Сводка:
            //     SYS FFC Status
            //     This command returns the Flat-Field Correction normalization (FFC) status.
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value –
            //     ffcStatusPtr
            //     – LEP_SYS_STATUS_WRITE_ERROR – LEP_SYS_FRAME_AVERAGE_COLLECTING_FRAMES – LEP_SYS_STATUS_READY
            //     –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x44
            //     SDK Data Length: Get 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysFFCStatus() – Returns the current status
            //     of the FFC operation in ffcStatusPtr –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysFFCStatus( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_STATUS_E_PTR
            //     ffcStatusPtr )) typedef enum { LEP_SYS_STATUS_WRITE_ERROR = -2, // LEP_SYS_STATUS_ERROR
            //     = -1, LEP_SYS_STATUS_READY = 0, LEP_SYS_STATUS_BUSY, LEP_SYS_FRAME_AVERAGE_COLLECTING_FRAMES,
            //     LEP_SYS_STATUS_END } LEP_SYS_STATUS_E, *LEP_SYS_STATUS_E_PTR;
            public FFCStatus GetFFCStatus();
            //
            // Сводка:
            //     SYS FFC Status
            //     This command returns the Flat-Field Correction normalization (FFC) status.
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value –
            //     ffcStatusPtr
            //     – LEP_SYS_STATUS_WRITE_ERROR – LEP_SYS_FRAME_AVERAGE_COLLECTING_FRAMES – LEP_SYS_STATUS_READY
            //     –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x44
            //     SDK Data Length: Get 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysFFCStatus() – Returns the current status
            //     of the FFC operation in ffcStatusPtr –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysFFCStatus( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_STATUS_E_PTR
            //     ffcStatusPtr )) typedef enum { LEP_SYS_STATUS_WRITE_ERROR = -2, // LEP_SYS_STATUS_ERROR
            //     = -1, LEP_SYS_STATUS_READY = 0, LEP_SYS_STATUS_BUSY, LEP_SYS_FRAME_AVERAGE_COLLECTING_FRAMES,
            //     LEP_SYS_STATUS_END } LEP_SYS_STATUS_E, *LEP_SYS_STATUS_E_PTR;
            public FFCStatus GetFFCStatusChecked();
            //
            // Сводка:
            //     SYS FLIR Serial Number
            //     This command returns the Lepton Camera’s serial number as a 64-bit unsigned long
            //     integer (unsigned long long).
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x08
            //     SDK Data Length: Get 4 size of the LEP_UINT64 data type
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysFlirSerialNumber() – Returns the Lepton
            //     Camera’s serial number as a 64-bit unsigned long integer (unsigned long long).
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysFlirSerialNumber(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_FLIR_SERIAL_NUMBER_T_PTR sysSerialNumberBufPtr) typedef LEP_UINT64 LEP_SYS_FLIR_SERIAL_NUMBER_T,
            //     *LEP_SYS_FLIR_SERIAL_NUMBER_T_PTR;
            public ulong GetFlirSerialNumber();
            //
            // Сводка:
            //     SYS FLIR Serial Number
            //     This command returns the Lepton Camera’s serial number as a 64-bit unsigned long
            //     integer (unsigned long long).
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x08
            //     SDK Data Length: Get 4 size of the LEP_UINT64 data type
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysFlirSerialNumber() – Returns the Lepton
            //     Camera’s serial number as a 64-bit unsigned long integer (unsigned long long).
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysFlirSerialNumber(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_FLIR_SERIAL_NUMBER_T_PTR sysSerialNumberBufPtr) typedef LEP_UINT64 LEP_SYS_FLIR_SERIAL_NUMBER_T,
            //     *LEP_SYS_FLIR_SERIAL_NUMBER_T_PTR;
            public ulong GetFlirSerialNumberChecked();
            //
            // Сводка:
            //     SYS FPA Temperature Celsius – helper function
            //     This is a SDK command that returns the Lepton Camera’s FPA Temperature in degrees
            //     Celsius. This function has no command ID since it is a helper function and uses
            //     the function LEP_GetSysFpaTemperatureKelvin()to get the current temperature in
            //     Kelvin before converting to degrees Celsius.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Units – Scale factor –
            //     - – - – Degrees Celsius – N/A (float value) –
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysFpaTemperatureCelsius() – Returns the Lepton
            //     Camera’s FPA Temperature in degrees Celsius –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysFpaTemperatureCelsius(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_FPA_TEMPERATURE_CELSIUS_T_PTR fpaTemperaturePtr) typedef LEP_FLOAT32
            //     LEP_SYS_FPA_TEMPERATURE_CELSIUS_T, *LEP_SYS_FPA_TEMPERATURE_CELSIUS_T_PTR;
            public float GetFpaTemperatureCelsius();
            //
            // Сводка:
            //     SYS FPA Temperature Celsius – helper function
            //     This is a SDK command that returns the Lepton Camera’s FPA Temperature in degrees
            //     Celsius. This function has no command ID since it is a helper function and uses
            //     the function LEP_GetSysFpaTemperatureKelvin()to get the current temperature in
            //     Kelvin before converting to degrees Celsius.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Units – Scale factor –
            //     - – - – Degrees Celsius – N/A (float value) –
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysFpaTemperatureCelsius() – Returns the Lepton
            //     Camera’s FPA Temperature in degrees Celsius –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysFpaTemperatureCelsius(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_FPA_TEMPERATURE_CELSIUS_T_PTR fpaTemperaturePtr) typedef LEP_FLOAT32
            //     LEP_SYS_FPA_TEMPERATURE_CELSIUS_T, *LEP_SYS_FPA_TEMPERATURE_CELSIUS_T_PTR;
            public float GetFpaTemperatureCelsiusChecked();
            //
            // Сводка:
            //     SYS FPA Temperature Kelvin
            //     This command returns the Lepton Camera’s FPA Temperature in Kelvin.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Units – Scale factor –
            //     0 – 65535 – Kelvin – 100 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x14
            //     SDK Data Length: Get 1 size of the LEP_SYS_FPA_TEMPERATURE_KELVIN_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysFpaTemperatureKelvin() – Returns the Lepton
            //     Camera’s FPA Temperature in Kelvin –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysFpaTemperatureKelvin(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_FPA_TEMPERATURE_KELVIN_T_PTR fpaTemperaturePtr) typedef LEP_UINT16 LEP_SYS_FPA_TEMPERATURE_KELVIN_T,
            //     *LEP_SYS_FPA_TEMPERATURE_KELVIN_T_PTR;
            public ushort GetFpaTemperatureKelvin();
            //
            // Сводка:
            //     SYS FPA Temperature Kelvin
            //     This command returns the Lepton Camera’s FPA Temperature in Kelvin.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Units – Scale factor –
            //     0 – 65535 – Kelvin – 100 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x14
            //     SDK Data Length: Get 1 size of the LEP_SYS_FPA_TEMPERATURE_KELVIN_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysFpaTemperatureKelvin() – Returns the Lepton
            //     Camera’s FPA Temperature in Kelvin –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysFpaTemperatureKelvin(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_FPA_TEMPERATURE_KELVIN_T_PTR fpaTemperaturePtr) typedef LEP_UINT16 LEP_SYS_FPA_TEMPERATURE_KELVIN_T,
            //     *LEP_SYS_FPA_TEMPERATURE_KELVIN_T_PTR;
            public ushort GetFpaTemperatureKelvinChecked();
            public FrameAverageDivisor GetFramesToAverage();
            public FrameAverageDivisor GetFramesToAverageChecked();
            //
            // Сводка:
            //     SYS Gain Mode
            //     This command sets the gain state of the camera. High gain mode provides higher
            //     responsivity and lower noise metrics for normal operation (default). Low gain
            //     mode provides lower responsivity and higher noise metrics, but with the benefit
            //     of increased intra-scene range necessary to view hotter scenes. Auto gain mode
            //     allows the camera to automatically switch the gain mode based on the temperature
            //     of the scene and thresholds configurable by the user in the “SYS Gain Mode Object”
            //     command. Auto gain mode can only be enabled when radiometry mode is enabled due
            //     to the temperature measurement dependency.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_SYS_GAIN_MODE_HIGH – LEP_SYS_GAIN_MODE_AUTO – LEP_SYS_GAIN_MODE_HIGH – N/A
            //     – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x49
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetSysGainMode() – Returns the Lepton Camera’s current
            //     Gain mode in gainModePtr –
            //     Lepton 2.5, 3.5 – LEP_SetSysGainMode() – Sets the Lepton Camera’s current Gain
            //     mode to gainMode –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysGainMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_GAIN_MODE_E_PTR
            //     gainModePtr) LEP_RESULT LEP_SetSysGainMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_GAIN_MODE_E gainMode) typedef enum LEP_SYS_GAIN_MODE_E_TAG { LEP_SYS_GAIN_MODE_HIGH
            //     = 0, LEP_SYS_GAIN_MODE_LOW, LEP_SYS_GAIN_MODE_AUTO, LEP_SYS_END_GAIN_MODE, }
            //     LEP_SYS_GAIN_MODE_E, *LEP_SYS_GAIN_MODE_E_PTR;;
            public GainMode GetGainMode();
            //
            // Сводка:
            //     SYS Gain Mode
            //     This command sets the gain state of the camera. High gain mode provides higher
            //     responsivity and lower noise metrics for normal operation (default). Low gain
            //     mode provides lower responsivity and higher noise metrics, but with the benefit
            //     of increased intra-scene range necessary to view hotter scenes. Auto gain mode
            //     allows the camera to automatically switch the gain mode based on the temperature
            //     of the scene and thresholds configurable by the user in the “SYS Gain Mode Object”
            //     command. Auto gain mode can only be enabled when radiometry mode is enabled due
            //     to the temperature measurement dependency.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_SYS_GAIN_MODE_HIGH – LEP_SYS_GAIN_MODE_AUTO – LEP_SYS_GAIN_MODE_HIGH – N/A
            //     – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x49
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetSysGainMode() – Returns the Lepton Camera’s current
            //     Gain mode in gainModePtr –
            //     Lepton 2.5, 3.5 – LEP_SetSysGainMode() – Sets the Lepton Camera’s current Gain
            //     mode to gainMode –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysGainMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_GAIN_MODE_E_PTR
            //     gainModePtr) LEP_RESULT LEP_SetSysGainMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_GAIN_MODE_E gainMode) typedef enum LEP_SYS_GAIN_MODE_E_TAG { LEP_SYS_GAIN_MODE_HIGH
            //     = 0, LEP_SYS_GAIN_MODE_LOW, LEP_SYS_GAIN_MODE_AUTO, LEP_SYS_END_GAIN_MODE, }
            //     LEP_SYS_GAIN_MODE_E, *LEP_SYS_GAIN_MODE_E_PTR;;
            public GainMode GetGainModeChecked();
            //
            // Сводка:
            //     SYS Gain Mode Object
            //     This command gets or sets the gain mode object. Set the ROI, temperature thresholds
            //     (in Celsius for TLinear disabled mode and Kelvin for TLinear enabled mode), and
            //     percentages of the ROI that must meet the temperature threshold criteria for
            //     both high to low and low to high automatic gain mode switching.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Field – Minimum Value – Maximum Value – Default Setting – Lepton 2.5 Factory
            //     Default – Units – Scale factor –
            //     sysGainModeROI
            //     – 0,0,0,0 – 59,59,79,79 – 0,0,59,79 – 0,0,59,79 – Pixels – 1 –
            //     sys_P_high_to_low
            //     – 0 – 100 – 20 – 25 – Percent – 1 –
            //     sys_P_low_to_high
            //     – 0 – 100 – 95 – 90 – Percent – 1 –
            //     sys_C_high_to_low
            //     – 0 – 600 – 110 – 115 – Celsius – 1 –
            //     sys_C_low_to_high
            //     – 0 – 600 – 90 – 85 – Celsius – 1 –
            //     sys_T_high_to_low
            //     – 0 – 900 – 383 – 388 – Kelvin – 1 –
            //     sys_T_low_to_high
            //     – 0 – 900 – 363 – 358 – Kelvin – 1 –
            //     sysGainRoiPopulation
            //     – 0 – 4800 – 4800 – 4800 – Pixels – 1 –
            //     sysGainModeTempEnabled
            //     – 0 – 1 – 0 – 0 – Boolean – 1 –
            //     sysGainModeFluxThresholdLow – 0 – 16383 – 8765 – Calibrated per camera – Counts
            //     – 1 –
            //     sysGainModeFluxThresholdHigh – 0 – 16383 – 9876 – Calibrated per camera – Counts
            //     – 1 –
            //     Lepton 3.0, 3.5
            //     Field – Minimum Value – Maximum Value – Default Setting – Lepton 3.5 Factory
            //     Default – Units – Scale factor –
            //     sysGainModeROI
            //     – 0,0,0,0 – 119,119,159,159 – 0,0,119,159 – 0,0,119,159 – Pixels – 1 –
            //     sys_P_high_to_low
            //     – 0 – 100 – 20 – 25 – Percent – 1 –
            //     sys_P_low_to_high
            //     – 0 – 100 – 95 – 90 – Percent – 1 –
            //     sys_C_high_to_low
            //     – 0 – 600 – 110 – 115 – Celsius – 1 –
            //     sys_C_low_to_high
            //     – 0 – 600 – 90 – 85 – Celsius – 1 –
            //     sys_T_high_to_low
            //     – 0 – 900 – 383 – 388 – Kelvin – 1 –
            //     sys_T_low_to_high
            //     – 0 – 900 – 363 – 358 – Kelvin – 1 –
            //     sysGainRoiPopulation
            //     – 0 – 19200 – 19200 – 19200 – Pixels – 1 –
            //     sysGainModeTempEnabled
            //     – 0 – 1 – 0 – 0 – Boolean – 1 –
            //     sysGainModeFluxThresholdLow – 0 – 16383 – 8765 – Calibrated per camera – Counts
            //     – 1 –
            //     sysGainModeFluxThresholdHigh – 0 – 16383 – 9876 – Calibrated per camera – Counts
            //     – 1 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x51
            //     SDK Data Length: Get 14 size of LEP_SYS_GAIN_MODE_OBJ_T Set 14 size of LEP_SYS_GAIN_MODE_OBJ_T
            //     data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetSysGainModeObj() – Returns the Lepton Camera’s current
            //     Gain mode in gainModeObjPtr –
            //     Lepton 2.5, 3.5 – LEP_SetSysGainModeObj() – Sets the Lepton Camera’s current
            //     Gain mode to gainModeObj –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysGainModeObj( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_GAIN_MODE_OBJ_T_PTR
            //     gainModeObjPtr ) LEP_RESULT LEP_SetSysGainModeObj( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_SYS_GAIN_MODE_OBJ_T gainModeObj ) /* Gain Mode Object */ typedef
            //     struct LEP_SYS_GAIN_MODE_OBJ_T_TAG { /* Specified ROI to use for Gain Mode switching
            //     */ /* Set of threshold triggers */ /* Population size in pixels within the ROI
            //     */ /* True if T-Linear is implemented */ /* calculated from desired temp */ /*
            //     calculated from desired temp */ }LEP_SYS_GAIN_MODE_OBJ_T, *LEP_SYS_GAIN_MODE_OBJ_T_PTR;
            //     /* System Gain Mode ROI Structure */ typedef struct LEP_SYS_GAIN_MODE_ROI_T_TAG
            //     { LEP_UINT16 startCol; LEP_UINT16 startRow; LEP_UINT16 endCol; LEP_UINT16 endRow;
            //     }LEP_SYS_GAIN_MODE_ROI_T, *LEP_SYS_GAIN_MODE_ROI_T_PTR; /* Gain Mode Support
            //     */ typedef struct LEP_SYS_GAIN_MODE_THRESHOLDS_T_TAG { /* Range: [0 - 100], percent
            //     */ /* Range: [0 - 100], percent */ /* Range: [0 - 600], degrees C */ /* Range:
            //     [0 - 600], degrees C */ /* Range: [0 - 900], Kelvin */ /* Range: [0 - 900], Kelvin
            //     */ }LEP_SYS_GAIN_MODE_THRESHOLDS_T, *LEP_SYS_GAIN_MODE_THRESHOLDS_T_PTR;
            public GainModeObj GetGainModeObj();
            //
            // Сводка:
            //     SYS Gain Mode Object
            //     This command gets or sets the gain mode object. Set the ROI, temperature thresholds
            //     (in Celsius for TLinear disabled mode and Kelvin for TLinear enabled mode), and
            //     percentages of the ROI that must meet the temperature threshold criteria for
            //     both high to low and low to high automatic gain mode switching.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Field – Minimum Value – Maximum Value – Default Setting – Lepton 2.5 Factory
            //     Default – Units – Scale factor –
            //     sysGainModeROI
            //     – 0,0,0,0 – 59,59,79,79 – 0,0,59,79 – 0,0,59,79 – Pixels – 1 –
            //     sys_P_high_to_low
            //     – 0 – 100 – 20 – 25 – Percent – 1 –
            //     sys_P_low_to_high
            //     – 0 – 100 – 95 – 90 – Percent – 1 –
            //     sys_C_high_to_low
            //     – 0 – 600 – 110 – 115 – Celsius – 1 –
            //     sys_C_low_to_high
            //     – 0 – 600 – 90 – 85 – Celsius – 1 –
            //     sys_T_high_to_low
            //     – 0 – 900 – 383 – 388 – Kelvin – 1 –
            //     sys_T_low_to_high
            //     – 0 – 900 – 363 – 358 – Kelvin – 1 –
            //     sysGainRoiPopulation
            //     – 0 – 4800 – 4800 – 4800 – Pixels – 1 –
            //     sysGainModeTempEnabled
            //     – 0 – 1 – 0 – 0 – Boolean – 1 –
            //     sysGainModeFluxThresholdLow – 0 – 16383 – 8765 – Calibrated per camera – Counts
            //     – 1 –
            //     sysGainModeFluxThresholdHigh – 0 – 16383 – 9876 – Calibrated per camera – Counts
            //     – 1 –
            //     Lepton 3.0, 3.5
            //     Field – Minimum Value – Maximum Value – Default Setting – Lepton 3.5 Factory
            //     Default – Units – Scale factor –
            //     sysGainModeROI
            //     – 0,0,0,0 – 119,119,159,159 – 0,0,119,159 – 0,0,119,159 – Pixels – 1 –
            //     sys_P_high_to_low
            //     – 0 – 100 – 20 – 25 – Percent – 1 –
            //     sys_P_low_to_high
            //     – 0 – 100 – 95 – 90 – Percent – 1 –
            //     sys_C_high_to_low
            //     – 0 – 600 – 110 – 115 – Celsius – 1 –
            //     sys_C_low_to_high
            //     – 0 – 600 – 90 – 85 – Celsius – 1 –
            //     sys_T_high_to_low
            //     – 0 – 900 – 383 – 388 – Kelvin – 1 –
            //     sys_T_low_to_high
            //     – 0 – 900 – 363 – 358 – Kelvin – 1 –
            //     sysGainRoiPopulation
            //     – 0 – 19200 – 19200 – 19200 – Pixels – 1 –
            //     sysGainModeTempEnabled
            //     – 0 – 1 – 0 – 0 – Boolean – 1 –
            //     sysGainModeFluxThresholdLow – 0 – 16383 – 8765 – Calibrated per camera – Counts
            //     – 1 –
            //     sysGainModeFluxThresholdHigh – 0 – 16383 – 9876 – Calibrated per camera – Counts
            //     – 1 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x51
            //     SDK Data Length: Get 14 size of LEP_SYS_GAIN_MODE_OBJ_T Set 14 size of LEP_SYS_GAIN_MODE_OBJ_T
            //     data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetSysGainModeObj() – Returns the Lepton Camera’s current
            //     Gain mode in gainModeObjPtr –
            //     Lepton 2.5, 3.5 – LEP_SetSysGainModeObj() – Sets the Lepton Camera’s current
            //     Gain mode to gainModeObj –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysGainModeObj( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_GAIN_MODE_OBJ_T_PTR
            //     gainModeObjPtr ) LEP_RESULT LEP_SetSysGainModeObj( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_SYS_GAIN_MODE_OBJ_T gainModeObj ) /* Gain Mode Object */ typedef
            //     struct LEP_SYS_GAIN_MODE_OBJ_T_TAG { /* Specified ROI to use for Gain Mode switching
            //     */ /* Set of threshold triggers */ /* Population size in pixels within the ROI
            //     */ /* True if T-Linear is implemented */ /* calculated from desired temp */ /*
            //     calculated from desired temp */ }LEP_SYS_GAIN_MODE_OBJ_T, *LEP_SYS_GAIN_MODE_OBJ_T_PTR;
            //     /* System Gain Mode ROI Structure */ typedef struct LEP_SYS_GAIN_MODE_ROI_T_TAG
            //     { LEP_UINT16 startCol; LEP_UINT16 startRow; LEP_UINT16 endCol; LEP_UINT16 endRow;
            //     }LEP_SYS_GAIN_MODE_ROI_T, *LEP_SYS_GAIN_MODE_ROI_T_PTR; /* Gain Mode Support
            //     */ typedef struct LEP_SYS_GAIN_MODE_THRESHOLDS_T_TAG { /* Range: [0 - 100], percent
            //     */ /* Range: [0 - 100], percent */ /* Range: [0 - 600], degrees C */ /* Range:
            //     [0 - 600], degrees C */ /* Range: [0 - 900], Kelvin */ /* Range: [0 - 900], Kelvin
            //     */ }LEP_SYS_GAIN_MODE_THRESHOLDS_T, *LEP_SYS_GAIN_MODE_THRESHOLDS_T_PTR;
            public GainModeObj GetGainModeObjChecked();
            //
            // Сводка:
            //     SYS Scene ROI Select
            //     The camera supports processing of pixels contained within a specified rectangular
            //     window or Region of Interest (ROI) to calculate scene statistics (See 4.4.23).
            //     This region is defined by 4 parameters: start column, start row, end column,
            //     and end row. The region is adjustable to a sub-window. Maximum extents must exclude
            //     a 1-pixel boundary from any edge.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column – 0 – pixels – 1 –
            //     start row
            //     – 0 – < end row – 0 – pixels – 1 –
            //     end column
            //     – > start column – 79 – 79 – pixels – 1 –
            //     end row
            //     – > start row – 59 – 59 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column – 0 – pixels – 1 –
            //     start row
            //     – 0 – < end row – 0 – pixels – 1 –
            //     end column
            //     – > start column – 159 – 159 – pixels – 1 –
            //     end row
            //     – > start row – 119 – 119 – pixels – 1 –
            //     SDK Module ID: VID 0x0200
            //     SDK Command ID: Base With Get 0x30
            //     With Set 0x31
            //     SDK Data Length: Get 4 size of LEP_SYS_VIDEO_ROI_T data type
            //     Set 4 size of LEP_SYS_VIDEO_ROI_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysSceneRoi() – Updates sceneRoiPtr with the
            //     Camera’s current Scene ROI –
            //     All Lepton Configurations – LEP_ SetSysSceneRoi() – Sets Camera’s current Scene
            //     ROI to sceneRoi –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysSceneRoi(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_VIDEO_ROI_T_PTR
            //     sceneRoiPtr) LEP_RESULT LEP_SetSysSceneRoi(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_VIDEO_ROI_T sceneRoi) /* SYS Scene ROI Structure */ typedef struct LEP_SYS_VIDEO_ROI_T_TAG
            //     { LEP_UINT16 startCol; LEP_UINT16 startRow; LEP_UINT16 endCol; LEP_UINT16 endRow;
            //     } LEP_SYS_VIDEO_ROI_T, *LEP_SYS_VIDEO_ROI_T_PTR;
            public VideoRoi GetSceneRoi();
            //
            // Сводка:
            //     SYS Scene ROI Select
            //     The camera supports processing of pixels contained within a specified rectangular
            //     window or Region of Interest (ROI) to calculate scene statistics (See 4.4.23).
            //     This region is defined by 4 parameters: start column, start row, end column,
            //     and end row. The region is adjustable to a sub-window. Maximum extents must exclude
            //     a 1-pixel boundary from any edge.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column – 0 – pixels – 1 –
            //     start row
            //     – 0 – < end row – 0 – pixels – 1 –
            //     end column
            //     – > start column – 79 – 79 – pixels – 1 –
            //     end row
            //     – > start row – 59 – 59 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column – 0 – pixels – 1 –
            //     start row
            //     – 0 – < end row – 0 – pixels – 1 –
            //     end column
            //     – > start column – 159 – 159 – pixels – 1 –
            //     end row
            //     – > start row – 119 – 119 – pixels – 1 –
            //     SDK Module ID: VID 0x0200
            //     SDK Command ID: Base With Get 0x30
            //     With Set 0x31
            //     SDK Data Length: Get 4 size of LEP_SYS_VIDEO_ROI_T data type
            //     Set 4 size of LEP_SYS_VIDEO_ROI_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysSceneRoi() – Updates sceneRoiPtr with the
            //     Camera’s current Scene ROI –
            //     All Lepton Configurations – LEP_ SetSysSceneRoi() – Sets Camera’s current Scene
            //     ROI to sceneRoi –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysSceneRoi(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_VIDEO_ROI_T_PTR
            //     sceneRoiPtr) LEP_RESULT LEP_SetSysSceneRoi(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_VIDEO_ROI_T sceneRoi) /* SYS Scene ROI Structure */ typedef struct LEP_SYS_VIDEO_ROI_T_TAG
            //     { LEP_UINT16 startCol; LEP_UINT16 startRow; LEP_UINT16 endCol; LEP_UINT16 endRow;
            //     } LEP_SYS_VIDEO_ROI_T, *LEP_SYS_VIDEO_ROI_T_PTR;
            public VideoRoi GetSceneRoiChecked();
            //
            // Сводка:
            //     SYS Camera Video Scene Statistics
            //     This command returns the current scene statistics for the video frame defined
            //     by the SYS ROI (see section 4.4.24 ). The statistics captured are scene mean
            //     intensity in counts, minimum and maximum intensity in counts, and the number
            //     of pixels in the ROI. Lepton scene intensities range from 0 to 16383. The range
            //     drops to 0 to 255 when in 8-bit AGC mode. Maximum number of pixels in the scene
            //     depends upon which camera, see below tables. When TLinear mode is enabled (available
            //     in the Radiometric releases), the camera output represents temperature values,
            //     and the scene statistics are reported in Kelvin x 100.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Units – Scale factor –
            //     minimum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     maximum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     mean intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     number of pixels
            //     – 0 – 4,800 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Units – Scale factor –
            //     minimum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     maximum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     mean intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     number of pixels
            //     – 0 – 19,200 – pixels – 1 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x2C
            //     SDK Data Length: Get 4 Returns four 16-bit values
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysSceneStatistics() – Updates sceneStatisticsPtr
            //     with the Camera’s current scene statistics. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysSceneStatistics( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_SCENE_STATISTICS_T_PTR sceneStatisticsPtr ) typedef struct LEP_SYS_SCENE_STATISTICS_T_TAG
            //     { LEP_UINT16 meanIntensity; LEP_UINT16 maxIntensity; LEP_UINT16 minIntensity;
            //     LEP_UINT16 numPixels; } LEP_SYS_SCENE_STATISTICS_T, *LEP_SYS_SCENE_STATISTICS_T_PTR;
            public SceneStatistics GetSceneStatistics();
            //
            // Сводка:
            //     SYS Camera Video Scene Statistics
            //     This command returns the current scene statistics for the video frame defined
            //     by the SYS ROI (see section 4.4.24 ). The statistics captured are scene mean
            //     intensity in counts, minimum and maximum intensity in counts, and the number
            //     of pixels in the ROI. Lepton scene intensities range from 0 to 16383. The range
            //     drops to 0 to 255 when in 8-bit AGC mode. Maximum number of pixels in the scene
            //     depends upon which camera, see below tables. When TLinear mode is enabled (available
            //     in the Radiometric releases), the camera output represents temperature values,
            //     and the scene statistics are reported in Kelvin x 100.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Units – Scale factor –
            //     minimum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     maximum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     mean intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     number of pixels
            //     – 0 – 4,800 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Units – Scale factor –
            //     minimum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     maximum intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     mean intensity
            //     – 0 – 2^14 -1 – pixels – 1 –
            //     number of pixels
            //     – 0 – 19,200 – pixels – 1 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x2C
            //     SDK Data Length: Get 4 Returns four 16-bit values
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysSceneStatistics() – Updates sceneStatisticsPtr
            //     with the Camera’s current scene statistics. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysSceneStatistics( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_SCENE_STATISTICS_T_PTR sceneStatisticsPtr ) typedef struct LEP_SYS_SCENE_STATISTICS_T_TAG
            //     { LEP_UINT16 meanIntensity; LEP_UINT16 maxIntensity; LEP_UINT16 minIntensity;
            //     LEP_UINT16 numPixels; } LEP_SYS_SCENE_STATISTICS_T, *LEP_SYS_SCENE_STATISTICS_T_PTR;
            public SceneStatistics GetSceneStatisticsChecked();
            public ShutterPosition GetShutterPosition();
            public ShutterPosition GetShutterPositionChecked();
            //
            // Сводка:
            //     SYS Status
            //     This command returns the system status: System Ready, System Initializing, System
            //     in Low-Power Mode, System Going into Standby, and FFC in Progress.
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x04
            //     SDK Data Length: Get 4 size of the LEP_STATUS_T data type
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysStatus() – Updates sysStatusPtr with the
            //     Camera’s current system status –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysStatus(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_STATUS_T_PTR
            //     sysStatusPtr) typedef struct { LEP_SYSTEM_STATUS_STATES_E camStatus; LEP_UINT16
            //     commandCount; LEP_UINT16 reserved; }LEP_STATUS_T, *LEP_STATUS_T_PTR; typedef
            //     enum LEP_SYSTEM_STATUS_STATES_E_TAG { LEP_SYSTEM_READY=0, LEP_SYSTEM_INITIALIZING,
            //     LEP_SYSTEM_IN_LOW_POWER_MODE, LEP_SYSTEM_GOING_INTO_STANDBY, LEP_SYSTEM_FLAT_FIELD_IN_PROCESS,
            //     LEP_SYSTEM_END_STATES }LEP_SYSTEM_STATUS_STATES_E, *LEP_SYSTEM_STATUS_STATES_E_PTR;
            public Status GetStatus();
            //
            // Сводка:
            //     SYS Status
            //     This command returns the system status: System Ready, System Initializing, System
            //     in Low-Power Mode, System Going into Standby, and FFC in Progress.
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x04
            //     SDK Data Length: Get 4 size of the LEP_STATUS_T data type
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysStatus() – Updates sysStatusPtr with the
            //     Camera’s current system status –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysStatus(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_STATUS_T_PTR
            //     sysStatusPtr) typedef struct { LEP_SYSTEM_STATUS_STATES_E camStatus; LEP_UINT16
            //     commandCount; LEP_UINT16 reserved; }LEP_STATUS_T, *LEP_STATUS_T_PTR; typedef
            //     enum LEP_SYSTEM_STATUS_STATES_E_TAG { LEP_SYSTEM_READY=0, LEP_SYSTEM_INITIALIZING,
            //     LEP_SYSTEM_IN_LOW_POWER_MODE, LEP_SYSTEM_GOING_INTO_STANDBY, LEP_SYSTEM_FLAT_FIELD_IN_PROCESS,
            //     LEP_SYSTEM_END_STATES }LEP_SYSTEM_STATUS_STATES_E, *LEP_SYSTEM_STATUS_STATES_E_PTR;
            public Status GetStatusChecked();
            //
            // Сводка:
            //     SYS Telemetry Enable State
            //     This command returns the Telemetry Enabled State as an Enum.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_TELEMETRY_DISABLED – LEP_TELEMETRY_ENABLED – LEP_TELEMETRY_DISABLED – N/A
            //     – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x19
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_ GetSysTelemetryEnableState() – Returns the Lepton
            //     Camera’s Telemetry Enable State –
            //     All Lepton Configurations – LEP_ SetSysTelemetryEnableState() – Sets the Lepton
            //     Camera’s Telemetry Enabled State –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysTelemetryEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_TELEMETRY_ENABLE_STATE_E_PTR enableStatePtr) LEP_RESULT LEP_SetSysTelemetryEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_SYS_TELEMETRY_ENABLE_STATE_E enableState) typedef enum LEP_SYS_TELEMETRY_ENABLE_STATE_E_TAG
            //     { LEP_TELEMETRY_DISABLED=0, LEP_TELEMETRY_ENABLED, LEP_END_TELEMETRY_ENABLE_STATE
            //     }LEP_SYS_TELEMETRY_ENABLE_STATE_E, *LEP_SYS_TELEMETRY_ENABLE_STATE_E_PTR;
            public TelemetryEnableState GetTelemetryEnableState();
            //
            // Сводка:
            //     SYS Telemetry Enable State
            //     This command returns the Telemetry Enabled State as an Enum.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_TELEMETRY_DISABLED – LEP_TELEMETRY_ENABLED – LEP_TELEMETRY_DISABLED – N/A
            //     – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x19
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_ GetSysTelemetryEnableState() – Returns the Lepton
            //     Camera’s Telemetry Enable State –
            //     All Lepton Configurations – LEP_ SetSysTelemetryEnableState() – Sets the Lepton
            //     Camera’s Telemetry Enabled State –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysTelemetryEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_TELEMETRY_ENABLE_STATE_E_PTR enableStatePtr) LEP_RESULT LEP_SetSysTelemetryEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_SYS_TELEMETRY_ENABLE_STATE_E enableState) typedef enum LEP_SYS_TELEMETRY_ENABLE_STATE_E_TAG
            //     { LEP_TELEMETRY_DISABLED=0, LEP_TELEMETRY_ENABLED, LEP_END_TELEMETRY_ENABLE_STATE
            //     }LEP_SYS_TELEMETRY_ENABLE_STATE_E, *LEP_SYS_TELEMETRY_ENABLE_STATE_E_PTR;
            public TelemetryEnableState GetTelemetryEnableStateChecked();
            //
            // Сводка:
            //     SYS Telemetry Location
            //     This command Sets and Gets the Telemetry Location.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_TELEMETRY_LOCATION_HEADER – LEP_TELEMETRY_LOCATION_FOOTER – LEP_TELEMETRY_LOCATION_FOOTER
            //     – N/A – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x1D
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_ GetSysTelemetryLocation() – Returns the location
            //     of Telemetry data as an enum –
            //     All Lepton Configurations – LEP_ SetSysTelemetryLocation() – Sets the location
            //     of Telemetry data as an enum –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysTelemetryLocation(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_TELEMETRY_LOCATION_E_PTR telemetryLocationPtr) LEP_RESULT LEP_SetSysTelemetryLocation(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_SYS_TELEMETRY_LOCATION_E telemetryLocation) typedef enum LEP_SYS_TELEMETRY_LOCATION_E_TAG
            //     { LEP_TELEMETRY_LOCATION_HEADER=0, LEP_TELEMETRY_LOCATION_FOOTER, LEP_END_TELEMETRY_LOCATION
            //     }LEP_SYS_TELEMETRY_LOCATION_E, *LEP_SYS_TELEMETRY_LOCATION_E_PTR;
            public TelemetryLocation GetTelemetryLocation();
            //
            // Сводка:
            //     SYS Telemetry Location
            //     This command Sets and Gets the Telemetry Location.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_TELEMETRY_LOCATION_HEADER – LEP_TELEMETRY_LOCATION_FOOTER – LEP_TELEMETRY_LOCATION_FOOTER
            //     – N/A – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x1D
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_ GetSysTelemetryLocation() – Returns the location
            //     of Telemetry data as an enum –
            //     All Lepton Configurations – LEP_ SetSysTelemetryLocation() – Sets the location
            //     of Telemetry data as an enum –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysTelemetryLocation(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_TELEMETRY_LOCATION_E_PTR telemetryLocationPtr) LEP_RESULT LEP_SetSysTelemetryLocation(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_SYS_TELEMETRY_LOCATION_E telemetryLocation) typedef enum LEP_SYS_TELEMETRY_LOCATION_E_TAG
            //     { LEP_TELEMETRY_LOCATION_HEADER=0, LEP_TELEMETRY_LOCATION_FOOTER, LEP_END_TELEMETRY_LOCATION
            //     }LEP_SYS_TELEMETRY_LOCATION_E, *LEP_SYS_TELEMETRY_LOCATION_E_PTR;
            public TelemetryLocation GetTelemetryLocationChecked();
            //
            // Сводка:
            //     SYS Thermal Shutdown Count
            //     This command returns the current number of frames remaining before a thermal
            //     shutdown is executed once the camera temperature exceeds a high-temperature threshold
            //     (around 80 degrees C). Once the camera detects the camera exceeded the thermal
            //     threshold, this counter begins to count down until zero. When the count reaches
            //     ZERO, the camera will shut itself down. A host can use this value to determine
            //     when the camera shuts down due to thermal conditions. The default value of 270
            //     is just over 10 seconds at 26 Hz video.
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     thermalCounts
            //     – 0 – 65535 – 270 – pixels – 1 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x34
            //     SDK Data Length: Get 1 Returns one 16-bit value
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysThermalShutdownCount() – Updates thermalCountsPtr
            //     with the Camera’s current thermal shut down count value. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysThermalShutdownCount(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_THERMAL_SHUTDOWN_COUNTS_T_PTR thermalCountsPtr) LEP_SYS_THERMAL_SHUTDOWN_COUNTS_T,
            //     *LEP_SYS_THERMAL_SHUTDOWN_COUNTS_T_PTR
            public ushort GetThermalShutdownCount();
            //
            // Сводка:
            //     SYS Thermal Shutdown Count
            //     This command returns the current number of frames remaining before a thermal
            //     shutdown is executed once the camera temperature exceeds a high-temperature threshold
            //     (around 80 degrees C). Once the camera detects the camera exceeded the thermal
            //     threshold, this counter begins to count down until zero. When the count reaches
            //     ZERO, the camera will shut itself down. A host can use this value to determine
            //     when the camera shuts down due to thermal conditions. The default value of 270
            //     is just over 10 seconds at 26 Hz video.
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     thermalCounts
            //     – 0 – 65535 – 270 – pixels – 1 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get 0x34
            //     SDK Data Length: Get 1 Returns one 16-bit value
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysThermalShutdownCount() – Updates thermalCountsPtr
            //     with the Camera’s current thermal shut down count value. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysThermalShutdownCount(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_THERMAL_SHUTDOWN_COUNTS_T_PTR thermalCountsPtr) LEP_SYS_THERMAL_SHUTDOWN_COUNTS_T,
            //     *LEP_SYS_THERMAL_SHUTDOWN_COUNTS_T_PTR
            public ushort GetThermalShutdownCountChecked();
            //
            // Сводка:
            //     SYS Average Frames – Aggregate Command
            //     This is an SDK aggregate command that executes the frame average command using
            //     a parameter to specify the number of frames to average.
            //     Executing this command causes the camera to sum together a number of frames,
            //     divide the summed frame by the number of frames summed and generate a result
            //     frame containing the average of the summed frames. The number of frames to average
            //     is specified by parameter to this function.
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0 – LEP_RunSysAverageFrames() – Executes the frame average
            //     command using the number of frames to average is specified by parameter to this
            //     function. Aggregate command. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunSysAverageFrames (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_FRAME_AVERAGE_DIVISOR_E
            //     numFrameToAverage); typedef enum LEP_SYS_FRAME_AVERAGE_DIVISOR_E_TAG { LEP_SYS_FA_DIV_1
            //     = 0, LEP_SYS_FA_DIV_2, LEP_SYS_FA_DIV_4, LEP_SYS_FA_DIV_8, LEP_SYS_FA_DIV_16,
            //     LEP_SYS_FA_DIV_32, LEP_SYS_FA_DIV_64, LEP_SYS_FA_DIV_128, LEP_SYS_END_FA_DIV
            //     }LEP_SYS_FRAME_AVERAGE_DIVISOR_E, *LEP_SYS_FRAME_AVERAGE_DIVISOR_E_PTR;
            public void RunAverageFrames(FrameAverageDivisor arg);
            //
            // Сводка:
            //     SYS Average Frames – Aggregate Command
            //     This is an SDK aggregate command that executes the frame average command using
            //     a parameter to specify the number of frames to average.
            //     Executing this command causes the camera to sum together a number of frames,
            //     divide the summed frame by the number of frames summed and generate a result
            //     frame containing the average of the summed frames. The number of frames to average
            //     is specified by parameter to this function.
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 1.5, 1.6, 2.0 – LEP_RunSysAverageFrames() – Executes the frame average
            //     command using the number of frames to average is specified by parameter to this
            //     function. Aggregate command. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunSysAverageFrames (LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_FRAME_AVERAGE_DIVISOR_E
            //     numFrameToAverage); typedef enum LEP_SYS_FRAME_AVERAGE_DIVISOR_E_TAG { LEP_SYS_FA_DIV_1
            //     = 0, LEP_SYS_FA_DIV_2, LEP_SYS_FA_DIV_4, LEP_SYS_FA_DIV_8, LEP_SYS_FA_DIV_16,
            //     LEP_SYS_FA_DIV_32, LEP_SYS_FA_DIV_64, LEP_SYS_FA_DIV_128, LEP_SYS_END_FA_DIV
            //     }LEP_SYS_FRAME_AVERAGE_DIVISOR_E, *LEP_SYS_FRAME_AVERAGE_DIVISOR_E_PTR;
            public void RunAverageFramesChecked(FrameAverageDivisor arg);
            //
            // Сводка:
            //     SYS Run FFC Normalization
            //     This command executes the camera’s Flat-Field Correction (FFC) normalization.
            //     This command executes synchronously. Internally this command polls the camera
            //     status to determine when this command completes (see LEP_GetSysFFCStatus() ),
            //     and only returns when completed.
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Run 0x42
            //     SDK Data Length: Run 0 size a run command argument
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunSysFFCNormalization() – Executes the FFC command.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunSysFFCNormalization(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunFFCNormalization();
            //
            // Сводка:
            //     SYS Run FFC Normalization
            //     This command executes the camera’s Flat-Field Correction (FFC) normalization.
            //     This command executes synchronously. Internally this command polls the camera
            //     status to determine when this command completes (see LEP_GetSysFFCStatus() ),
            //     and only returns when completed.
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Run 0x42
            //     SDK Data Length: Run 0 size a run command argument
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunSysFFCNormalization() – Executes the FFC command.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunSysFFCNormalization(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunFFCNormalizationChecked();
            //
            // Сводка:
            //     SYS Frame Average
            //     This command executes the average frames command. Executing this command causes
            //     the camera to sum together a number of frames, divide the summed frame by the
            //     number of frames summed and generate a result frame containing the average of
            //     the summed frames.
            //     For Lepton 1.5, 1.6, 2.0 and 2.5, the number of frames to average is set by LEP_SYS_SetFramesToAverage().
            //     For Lepton 3.0 and 3.5, the number of frames is currently fixed at 8.
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Run 0x22
            //     SDK Data Length: Run 0 size a run command argument
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunFrameAverage() – Executes the frame average
            //     command. The number of frames to average is set by separate command: LEP_SYS_SetFramesToAverage().
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunFrameAverage(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunFrameAverage();
            //
            // Сводка:
            //     SYS Frame Average
            //     This command executes the average frames command. Executing this command causes
            //     the camera to sum together a number of frames, divide the summed frame by the
            //     number of frames summed and generate a result frame containing the average of
            //     the summed frames.
            //     For Lepton 1.5, 1.6, 2.0 and 2.5, the number of frames to average is set by LEP_SYS_SetFramesToAverage().
            //     For Lepton 3.0 and 3.5, the number of frames is currently fixed at 8.
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Run 0x22
            //     SDK Data Length: Run 0 size a run command argument
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunFrameAverage() – Executes the frame average
            //     command. The number of frames to average is set by separate command: LEP_SYS_SetFramesToAverage().
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunFrameAverage(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunFrameAverageChecked();
            //
            // Сводка:
            //     SYS Ping Camera
            //     This function sends the ping command to the camera. The camera will respond with
            //     LEP_OK if command received correctly.
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Run 0x02
            //     SDK Data Length: Run 0 size a run command argument is zero
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunSysPing() – Issues a ping command to the Camera
            //     to check if communication is up. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunSysPing(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunPing();
            //
            // Сводка:
            //     SYS Ping Camera
            //     This function sends the ping command to the camera. The camera will respond with
            //     LEP_OK if command received correctly.
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Run 0x02
            //     SDK Data Length: Run 0 size a run command argument is zero
            //
            // Примечания:
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_RunSysPing() – Issues a ping command to the Camera
            //     to check if communication is up. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_RunSysPing(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr);
            public void RunPingChecked();
            public void SetFfcShutterModeObj(FfcShutterModeObj source);
            public void SetFfcShutterModeObjChecked(FfcShutterModeObj source);
            public void SetFramesToAverage(FrameAverageDivisor source);
            public void SetFramesToAverageChecked(FrameAverageDivisor source);
            //
            // Сводка:
            //     SYS Gain Mode
            //     This command sets the gain state of the camera. High gain mode provides higher
            //     responsivity and lower noise metrics for normal operation (default). Low gain
            //     mode provides lower responsivity and higher noise metrics, but with the benefit
            //     of increased intra-scene range necessary to view hotter scenes. Auto gain mode
            //     allows the camera to automatically switch the gain mode based on the temperature
            //     of the scene and thresholds configurable by the user in the “SYS Gain Mode Object”
            //     command. Auto gain mode can only be enabled when radiometry mode is enabled due
            //     to the temperature measurement dependency.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_SYS_GAIN_MODE_HIGH – LEP_SYS_GAIN_MODE_AUTO – LEP_SYS_GAIN_MODE_HIGH – N/A
            //     – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x49
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetSysGainMode() – Returns the Lepton Camera’s current
            //     Gain mode in gainModePtr –
            //     Lepton 2.5, 3.5 – LEP_SetSysGainMode() – Sets the Lepton Camera’s current Gain
            //     mode to gainMode –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysGainMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_GAIN_MODE_E_PTR
            //     gainModePtr) LEP_RESULT LEP_SetSysGainMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_GAIN_MODE_E gainMode) typedef enum LEP_SYS_GAIN_MODE_E_TAG { LEP_SYS_GAIN_MODE_HIGH
            //     = 0, LEP_SYS_GAIN_MODE_LOW, LEP_SYS_GAIN_MODE_AUTO, LEP_SYS_END_GAIN_MODE, }
            //     LEP_SYS_GAIN_MODE_E, *LEP_SYS_GAIN_MODE_E_PTR;;
            public void SetGainMode(GainMode source);
            //
            // Сводка:
            //     SYS Gain Mode
            //     This command sets the gain state of the camera. High gain mode provides higher
            //     responsivity and lower noise metrics for normal operation (default). Low gain
            //     mode provides lower responsivity and higher noise metrics, but with the benefit
            //     of increased intra-scene range necessary to view hotter scenes. Auto gain mode
            //     allows the camera to automatically switch the gain mode based on the temperature
            //     of the scene and thresholds configurable by the user in the “SYS Gain Mode Object”
            //     command. Auto gain mode can only be enabled when radiometry mode is enabled due
            //     to the temperature measurement dependency.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_SYS_GAIN_MODE_HIGH – LEP_SYS_GAIN_MODE_AUTO – LEP_SYS_GAIN_MODE_HIGH – N/A
            //     – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x49
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetSysGainMode() – Returns the Lepton Camera’s current
            //     Gain mode in gainModePtr –
            //     Lepton 2.5, 3.5 – LEP_SetSysGainMode() – Sets the Lepton Camera’s current Gain
            //     mode to gainMode –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysGainMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_GAIN_MODE_E_PTR
            //     gainModePtr) LEP_RESULT LEP_SetSysGainMode( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_GAIN_MODE_E gainMode) typedef enum LEP_SYS_GAIN_MODE_E_TAG { LEP_SYS_GAIN_MODE_HIGH
            //     = 0, LEP_SYS_GAIN_MODE_LOW, LEP_SYS_GAIN_MODE_AUTO, LEP_SYS_END_GAIN_MODE, }
            //     LEP_SYS_GAIN_MODE_E, *LEP_SYS_GAIN_MODE_E_PTR;;
            public void SetGainModeChecked(GainMode source);
            //
            // Сводка:
            //     SYS Gain Mode Object
            //     This command gets or sets the gain mode object. Set the ROI, temperature thresholds
            //     (in Celsius for TLinear disabled mode and Kelvin for TLinear enabled mode), and
            //     percentages of the ROI that must meet the temperature threshold criteria for
            //     both high to low and low to high automatic gain mode switching.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Field – Minimum Value – Maximum Value – Default Setting – Lepton 2.5 Factory
            //     Default – Units – Scale factor –
            //     sysGainModeROI
            //     – 0,0,0,0 – 59,59,79,79 – 0,0,59,79 – 0,0,59,79 – Pixels – 1 –
            //     sys_P_high_to_low
            //     – 0 – 100 – 20 – 25 – Percent – 1 –
            //     sys_P_low_to_high
            //     – 0 – 100 – 95 – 90 – Percent – 1 –
            //     sys_C_high_to_low
            //     – 0 – 600 – 110 – 115 – Celsius – 1 –
            //     sys_C_low_to_high
            //     – 0 – 600 – 90 – 85 – Celsius – 1 –
            //     sys_T_high_to_low
            //     – 0 – 900 – 383 – 388 – Kelvin – 1 –
            //     sys_T_low_to_high
            //     – 0 – 900 – 363 – 358 – Kelvin – 1 –
            //     sysGainRoiPopulation
            //     – 0 – 4800 – 4800 – 4800 – Pixels – 1 –
            //     sysGainModeTempEnabled
            //     – 0 – 1 – 0 – 0 – Boolean – 1 –
            //     sysGainModeFluxThresholdLow – 0 – 16383 – 8765 – Calibrated per camera – Counts
            //     – 1 –
            //     sysGainModeFluxThresholdHigh – 0 – 16383 – 9876 – Calibrated per camera – Counts
            //     – 1 –
            //     Lepton 3.0, 3.5
            //     Field – Minimum Value – Maximum Value – Default Setting – Lepton 3.5 Factory
            //     Default – Units – Scale factor –
            //     sysGainModeROI
            //     – 0,0,0,0 – 119,119,159,159 – 0,0,119,159 – 0,0,119,159 – Pixels – 1 –
            //     sys_P_high_to_low
            //     – 0 – 100 – 20 – 25 – Percent – 1 –
            //     sys_P_low_to_high
            //     – 0 – 100 – 95 – 90 – Percent – 1 –
            //     sys_C_high_to_low
            //     – 0 – 600 – 110 – 115 – Celsius – 1 –
            //     sys_C_low_to_high
            //     – 0 – 600 – 90 – 85 – Celsius – 1 –
            //     sys_T_high_to_low
            //     – 0 – 900 – 383 – 388 – Kelvin – 1 –
            //     sys_T_low_to_high
            //     – 0 – 900 – 363 – 358 – Kelvin – 1 –
            //     sysGainRoiPopulation
            //     – 0 – 19200 – 19200 – 19200 – Pixels – 1 –
            //     sysGainModeTempEnabled
            //     – 0 – 1 – 0 – 0 – Boolean – 1 –
            //     sysGainModeFluxThresholdLow – 0 – 16383 – 8765 – Calibrated per camera – Counts
            //     – 1 –
            //     sysGainModeFluxThresholdHigh – 0 – 16383 – 9876 – Calibrated per camera – Counts
            //     – 1 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x51
            //     SDK Data Length: Get 14 size of LEP_SYS_GAIN_MODE_OBJ_T Set 14 size of LEP_SYS_GAIN_MODE_OBJ_T
            //     data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetSysGainModeObj() – Returns the Lepton Camera’s current
            //     Gain mode in gainModeObjPtr –
            //     Lepton 2.5, 3.5 – LEP_SetSysGainModeObj() – Sets the Lepton Camera’s current
            //     Gain mode to gainModeObj –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysGainModeObj( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_GAIN_MODE_OBJ_T_PTR
            //     gainModeObjPtr ) LEP_RESULT LEP_SetSysGainModeObj( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_SYS_GAIN_MODE_OBJ_T gainModeObj ) /* Gain Mode Object */ typedef
            //     struct LEP_SYS_GAIN_MODE_OBJ_T_TAG { /* Specified ROI to use for Gain Mode switching
            //     */ /* Set of threshold triggers */ /* Population size in pixels within the ROI
            //     */ /* True if T-Linear is implemented */ /* calculated from desired temp */ /*
            //     calculated from desired temp */ }LEP_SYS_GAIN_MODE_OBJ_T, *LEP_SYS_GAIN_MODE_OBJ_T_PTR;
            //     /* System Gain Mode ROI Structure */ typedef struct LEP_SYS_GAIN_MODE_ROI_T_TAG
            //     { LEP_UINT16 startCol; LEP_UINT16 startRow; LEP_UINT16 endCol; LEP_UINT16 endRow;
            //     }LEP_SYS_GAIN_MODE_ROI_T, *LEP_SYS_GAIN_MODE_ROI_T_PTR; /* Gain Mode Support
            //     */ typedef struct LEP_SYS_GAIN_MODE_THRESHOLDS_T_TAG { /* Range: [0 - 100], percent
            //     */ /* Range: [0 - 100], percent */ /* Range: [0 - 600], degrees C */ /* Range:
            //     [0 - 600], degrees C */ /* Range: [0 - 900], Kelvin */ /* Range: [0 - 900], Kelvin
            //     */ }LEP_SYS_GAIN_MODE_THRESHOLDS_T, *LEP_SYS_GAIN_MODE_THRESHOLDS_T_PTR;
            public void SetGainModeObj(GainModeObj source);
            //
            // Сводка:
            //     SYS Gain Mode Object
            //     This command gets or sets the gain mode object. Set the ROI, temperature thresholds
            //     (in Celsius for TLinear disabled mode and Kelvin for TLinear enabled mode), and
            //     percentages of the ROI that must meet the temperature threshold criteria for
            //     both high to low and low to high automatic gain mode switching.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Field – Minimum Value – Maximum Value – Default Setting – Lepton 2.5 Factory
            //     Default – Units – Scale factor –
            //     sysGainModeROI
            //     – 0,0,0,0 – 59,59,79,79 – 0,0,59,79 – 0,0,59,79 – Pixels – 1 –
            //     sys_P_high_to_low
            //     – 0 – 100 – 20 – 25 – Percent – 1 –
            //     sys_P_low_to_high
            //     – 0 – 100 – 95 – 90 – Percent – 1 –
            //     sys_C_high_to_low
            //     – 0 – 600 – 110 – 115 – Celsius – 1 –
            //     sys_C_low_to_high
            //     – 0 – 600 – 90 – 85 – Celsius – 1 –
            //     sys_T_high_to_low
            //     – 0 – 900 – 383 – 388 – Kelvin – 1 –
            //     sys_T_low_to_high
            //     – 0 – 900 – 363 – 358 – Kelvin – 1 –
            //     sysGainRoiPopulation
            //     – 0 – 4800 – 4800 – 4800 – Pixels – 1 –
            //     sysGainModeTempEnabled
            //     – 0 – 1 – 0 – 0 – Boolean – 1 –
            //     sysGainModeFluxThresholdLow – 0 – 16383 – 8765 – Calibrated per camera – Counts
            //     – 1 –
            //     sysGainModeFluxThresholdHigh – 0 – 16383 – 9876 – Calibrated per camera – Counts
            //     – 1 –
            //     Lepton 3.0, 3.5
            //     Field – Minimum Value – Maximum Value – Default Setting – Lepton 3.5 Factory
            //     Default – Units – Scale factor –
            //     sysGainModeROI
            //     – 0,0,0,0 – 119,119,159,159 – 0,0,119,159 – 0,0,119,159 – Pixels – 1 –
            //     sys_P_high_to_low
            //     – 0 – 100 – 20 – 25 – Percent – 1 –
            //     sys_P_low_to_high
            //     – 0 – 100 – 95 – 90 – Percent – 1 –
            //     sys_C_high_to_low
            //     – 0 – 600 – 110 – 115 – Celsius – 1 –
            //     sys_C_low_to_high
            //     – 0 – 600 – 90 – 85 – Celsius – 1 –
            //     sys_T_high_to_low
            //     – 0 – 900 – 383 – 388 – Kelvin – 1 –
            //     sys_T_low_to_high
            //     – 0 – 900 – 363 – 358 – Kelvin – 1 –
            //     sysGainRoiPopulation
            //     – 0 – 19200 – 19200 – 19200 – Pixels – 1 –
            //     sysGainModeTempEnabled
            //     – 0 – 1 – 0 – 0 – Boolean – 1 –
            //     sysGainModeFluxThresholdLow – 0 – 16383 – 8765 – Calibrated per camera – Counts
            //     – 1 –
            //     sysGainModeFluxThresholdHigh – 0 – 16383 – 9876 – Calibrated per camera – Counts
            //     – 1 –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x51
            //     SDK Data Length: Get 14 size of LEP_SYS_GAIN_MODE_OBJ_T Set 14 size of LEP_SYS_GAIN_MODE_OBJ_T
            //     data type
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetSysGainModeObj() – Returns the Lepton Camera’s current
            //     Gain mode in gainModeObjPtr –
            //     Lepton 2.5, 3.5 – LEP_SetSysGainModeObj() – Sets the Lepton Camera’s current
            //     Gain mode to gainModeObj –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysGainModeObj( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_GAIN_MODE_OBJ_T_PTR
            //     gainModeObjPtr ) LEP_RESULT LEP_SetSysGainModeObj( LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_SYS_GAIN_MODE_OBJ_T gainModeObj ) /* Gain Mode Object */ typedef
            //     struct LEP_SYS_GAIN_MODE_OBJ_T_TAG { /* Specified ROI to use for Gain Mode switching
            //     */ /* Set of threshold triggers */ /* Population size in pixels within the ROI
            //     */ /* True if T-Linear is implemented */ /* calculated from desired temp */ /*
            //     calculated from desired temp */ }LEP_SYS_GAIN_MODE_OBJ_T, *LEP_SYS_GAIN_MODE_OBJ_T_PTR;
            //     /* System Gain Mode ROI Structure */ typedef struct LEP_SYS_GAIN_MODE_ROI_T_TAG
            //     { LEP_UINT16 startCol; LEP_UINT16 startRow; LEP_UINT16 endCol; LEP_UINT16 endRow;
            //     }LEP_SYS_GAIN_MODE_ROI_T, *LEP_SYS_GAIN_MODE_ROI_T_PTR; /* Gain Mode Support
            //     */ typedef struct LEP_SYS_GAIN_MODE_THRESHOLDS_T_TAG { /* Range: [0 - 100], percent
            //     */ /* Range: [0 - 100], percent */ /* Range: [0 - 600], degrees C */ /* Range:
            //     [0 - 600], degrees C */ /* Range: [0 - 900], Kelvin */ /* Range: [0 - 900], Kelvin
            //     */ }LEP_SYS_GAIN_MODE_THRESHOLDS_T, *LEP_SYS_GAIN_MODE_THRESHOLDS_T_PTR;
            public void SetGainModeObjChecked(GainModeObj source);
            //
            // Сводка:
            //     SYS Scene ROI Select
            //     The camera supports processing of pixels contained within a specified rectangular
            //     window or Region of Interest (ROI) to calculate scene statistics (See 4.4.23).
            //     This region is defined by 4 parameters: start column, start row, end column,
            //     and end row. The region is adjustable to a sub-window. Maximum extents must exclude
            //     a 1-pixel boundary from any edge.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column – 0 – pixels – 1 –
            //     start row
            //     – 0 – < end row – 0 – pixels – 1 –
            //     end column
            //     – > start column – 79 – 79 – pixels – 1 –
            //     end row
            //     – > start row – 59 – 59 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column – 0 – pixels – 1 –
            //     start row
            //     – 0 – < end row – 0 – pixels – 1 –
            //     end column
            //     – > start column – 159 – 159 – pixels – 1 –
            //     end row
            //     – > start row – 119 – 119 – pixels – 1 –
            //     SDK Module ID: VID 0x0200
            //     SDK Command ID: Base With Get 0x30
            //     With Set 0x31
            //     SDK Data Length: Get 4 size of LEP_SYS_VIDEO_ROI_T data type
            //     Set 4 size of LEP_SYS_VIDEO_ROI_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysSceneRoi() – Updates sceneRoiPtr with the
            //     Camera’s current Scene ROI –
            //     All Lepton Configurations – LEP_ SetSysSceneRoi() – Sets Camera’s current Scene
            //     ROI to sceneRoi –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysSceneRoi(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_VIDEO_ROI_T_PTR
            //     sceneRoiPtr) LEP_RESULT LEP_SetSysSceneRoi(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_VIDEO_ROI_T sceneRoi) /* SYS Scene ROI Structure */ typedef struct LEP_SYS_VIDEO_ROI_T_TAG
            //     { LEP_UINT16 startCol; LEP_UINT16 startRow; LEP_UINT16 endCol; LEP_UINT16 endRow;
            //     } LEP_SYS_VIDEO_ROI_T, *LEP_SYS_VIDEO_ROI_T_PTR;
            public void SetSceneRoi(VideoRoi source);
            //
            // Сводка:
            //     SYS Scene ROI Select
            //     The camera supports processing of pixels contained within a specified rectangular
            //     window or Region of Interest (ROI) to calculate scene statistics (See 4.4.23).
            //     This region is defined by 4 parameters: start column, start row, end column,
            //     and end row. The region is adjustable to a sub-window. Maximum extents must exclude
            //     a 1-pixel boundary from any edge.
            //     Lepton 1.5, 1.6, 2.0, 2.5
            //
            // Примечания:
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column – 0 – pixels – 1 –
            //     start row
            //     – 0 – < end row – 0 – pixels – 1 –
            //     end column
            //     – > start column – 79 – 79 – pixels – 1 –
            //     end row
            //     – > start row – 59 – 59 – pixels – 1 –
            //     Lepton 3.0, 3.5
            //     Dimension – Minimum Value – Maximum Value – Default Value – Units – Scale factor
            //     –
            //     start column
            //     – 0 – < end column – 0 – pixels – 1 –
            //     start row
            //     – 0 – < end row – 0 – pixels – 1 –
            //     end column
            //     – > start column – 159 – 159 – pixels – 1 –
            //     end row
            //     – > start row – 119 – 119 – pixels – 1 –
            //     SDK Module ID: VID 0x0200
            //     SDK Command ID: Base With Get 0x30
            //     With Set 0x31
            //     SDK Data Length: Get 4 size of LEP_SYS_VIDEO_ROI_T data type
            //     Set 4 size of LEP_SYS_VIDEO_ROI_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetSysSceneRoi() – Updates sceneRoiPtr with the
            //     Camera’s current Scene ROI –
            //     All Lepton Configurations – LEP_ SetSysSceneRoi() – Sets Camera’s current Scene
            //     ROI to sceneRoi –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysSceneRoi(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_SYS_VIDEO_ROI_T_PTR
            //     sceneRoiPtr) LEP_RESULT LEP_SetSysSceneRoi(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_VIDEO_ROI_T sceneRoi) /* SYS Scene ROI Structure */ typedef struct LEP_SYS_VIDEO_ROI_T_TAG
            //     { LEP_UINT16 startCol; LEP_UINT16 startRow; LEP_UINT16 endCol; LEP_UINT16 endRow;
            //     } LEP_SYS_VIDEO_ROI_T, *LEP_SYS_VIDEO_ROI_T_PTR;
            public void SetSceneRoiChecked(VideoRoi source);
            public void SetShutterPosition(ShutterPosition source);
            public void SetShutterPositionChecked(ShutterPosition source);
            //
            // Сводка:
            //     SYS Telemetry Enable State
            //     This command returns the Telemetry Enabled State as an Enum.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_TELEMETRY_DISABLED – LEP_TELEMETRY_ENABLED – LEP_TELEMETRY_DISABLED – N/A
            //     – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x19
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_ GetSysTelemetryEnableState() – Returns the Lepton
            //     Camera’s Telemetry Enable State –
            //     All Lepton Configurations – LEP_ SetSysTelemetryEnableState() – Sets the Lepton
            //     Camera’s Telemetry Enabled State –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysTelemetryEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_TELEMETRY_ENABLE_STATE_E_PTR enableStatePtr) LEP_RESULT LEP_SetSysTelemetryEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_SYS_TELEMETRY_ENABLE_STATE_E enableState) typedef enum LEP_SYS_TELEMETRY_ENABLE_STATE_E_TAG
            //     { LEP_TELEMETRY_DISABLED=0, LEP_TELEMETRY_ENABLED, LEP_END_TELEMETRY_ENABLE_STATE
            //     }LEP_SYS_TELEMETRY_ENABLE_STATE_E, *LEP_SYS_TELEMETRY_ENABLE_STATE_E_PTR;
            public void SetTelemetryEnableState(TelemetryEnableState source);
            //
            // Сводка:
            //     SYS Telemetry Enable State
            //     This command returns the Telemetry Enabled State as an Enum.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_TELEMETRY_DISABLED – LEP_TELEMETRY_ENABLED – LEP_TELEMETRY_DISABLED – N/A
            //     – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x19
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_ GetSysTelemetryEnableState() – Returns the Lepton
            //     Camera’s Telemetry Enable State –
            //     All Lepton Configurations – LEP_ SetSysTelemetryEnableState() – Sets the Lepton
            //     Camera’s Telemetry Enabled State –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysTelemetryEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_TELEMETRY_ENABLE_STATE_E_PTR enableStatePtr) LEP_RESULT LEP_SetSysTelemetryEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_SYS_TELEMETRY_ENABLE_STATE_E enableState) typedef enum LEP_SYS_TELEMETRY_ENABLE_STATE_E_TAG
            //     { LEP_TELEMETRY_DISABLED=0, LEP_TELEMETRY_ENABLED, LEP_END_TELEMETRY_ENABLE_STATE
            //     }LEP_SYS_TELEMETRY_ENABLE_STATE_E, *LEP_SYS_TELEMETRY_ENABLE_STATE_E_PTR;
            public void SetTelemetryEnableStateChecked(TelemetryEnableState source);
            //
            // Сводка:
            //     SYS Telemetry Location
            //     This command Sets and Gets the Telemetry Location.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_TELEMETRY_LOCATION_HEADER – LEP_TELEMETRY_LOCATION_FOOTER – LEP_TELEMETRY_LOCATION_FOOTER
            //     – N/A – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x1D
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_ GetSysTelemetryLocation() – Returns the location
            //     of Telemetry data as an enum –
            //     All Lepton Configurations – LEP_ SetSysTelemetryLocation() – Sets the location
            //     of Telemetry data as an enum –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysTelemetryLocation(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_TELEMETRY_LOCATION_E_PTR telemetryLocationPtr) LEP_RESULT LEP_SetSysTelemetryLocation(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_SYS_TELEMETRY_LOCATION_E telemetryLocation) typedef enum LEP_SYS_TELEMETRY_LOCATION_E_TAG
            //     { LEP_TELEMETRY_LOCATION_HEADER=0, LEP_TELEMETRY_LOCATION_FOOTER, LEP_END_TELEMETRY_LOCATION
            //     }LEP_SYS_TELEMETRY_LOCATION_E, *LEP_SYS_TELEMETRY_LOCATION_E_PTR;
            public void SetTelemetryLocation(TelemetryLocation source);
            //
            // Сводка:
            //     SYS Telemetry Location
            //     This command Sets and Gets the Telemetry Location.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_TELEMETRY_LOCATION_HEADER – LEP_TELEMETRY_LOCATION_FOOTER – LEP_TELEMETRY_LOCATION_FOOTER
            //     – N/A – N/A –
            //     SDK Module ID: SYS 0x0200
            //     SDK Command ID: Base With Get With Set 0x1D
            //     SDK Data Length: Get 2 Set 2 size of an Enum on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_ GetSysTelemetryLocation() – Returns the location
            //     of Telemetry data as an enum –
            //     All Lepton Configurations – LEP_ SetSysTelemetryLocation() – Sets the location
            //     of Telemetry data as an enum –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetSysTelemetryLocation(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_SYS_TELEMETRY_LOCATION_E_PTR telemetryLocationPtr) LEP_RESULT LEP_SetSysTelemetryLocation(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_SYS_TELEMETRY_LOCATION_E telemetryLocation) typedef enum LEP_SYS_TELEMETRY_LOCATION_E_TAG
            //     { LEP_TELEMETRY_LOCATION_HEADER=0, LEP_TELEMETRY_LOCATION_FOOTER, LEP_END_TELEMETRY_LOCATION
            //     }LEP_SYS_TELEMETRY_LOCATION_E, *LEP_SYS_TELEMETRY_LOCATION_E_PTR;
            public void SetTelemetryLocationChecked(TelemetryLocation source);

            public enum FfcStates
            {
                FFC_NEVER_COMMANDED = 0,
                FFC_IMMINENT = 1,
                FFC_IN_PROCESS = 2,
                FFC_DONE = 3
            }
            public enum GainMode
            {
                HIGH = 0,
                LOW = 1,
                AUTO = 2
            }
            public enum FFCStatus
            {
                STATUS_WRITE_ERROR = -2,
                STATUS_ERROR = -1,
                STATUS_READY = 0,
                STATUS_BUSY = 1,
                FRAME_AVERAGE_COLLECTING_FRAMES = 2
            }
            public enum ShutterTempLockoutState
            {
                SHUTTER_LOCKOUT_INACTIVE = 0,
                SHUTTER_LOCKOUT_HIGH = 1,
                SHUTTER_LOCKOUT_LOW = 2
            }
            public enum FfcShutterMode
            {
                MANUAL = 0,
                AUTO = 1,
                EXTERNAL = 2
            }
            public enum Enable
            {
                DISABLE = 0,
                ENABLE = 1
            }
            public enum FrameAverageDivisor
            {
                FA_DIV_1 = 0,
                FA_DIV_2 = 1,
                FA_DIV_4 = 2,
                FA_DIV_8 = 3,
                FA_DIV_16 = 4,
                FA_DIV_32 = 5,
                FA_DIV_64 = 6,
                FA_DIV_128 = 7
            }
            public enum TelemetryLocation
            {
                HEADER = 0,
                FOOTER = 1
            }
            public enum TelemetryEnableState
            {
                TELEMETRY_DISABLED = 0,
                TELEMETRY_ENABLED = 1
            }
            public enum SystemStatusStates
            {
                SYSTEM_READY = 0,
                SYSTEM_INITIALIZING = 1,
                SYSTEM_IN_LOW_POWER_MODE = 2,
                SYSTEM_GOING_INTO_STANDBY = 3,
                SYSTEM_FLAT_FIELD_IN_PROCESS = 4,
                SYSTEM_FLAT_FIELD_IMMINENT = 5,
                SYSTEM_THERMAL_SHUTDOWN_IMMINENT = 6
            }
            public enum ShutterPosition
            {
                UNKNOWN = -1,
                IDLE = 0,
                OPEN = 1,
                CLOSED = 2,
                BRAKE_ON = 3
            }

            public class GainModeObj
            {
                public GainModeRoi sysGainModeROI;
                public GainModeThresholds sysGainModeThresholds;
                public ushort sysGainRoiPopulation;
                public ushort sysGainModeTempEnabled;
                public ushort sysGainModeFluxThresholdLow;
                public ushort sysGainModeFluxThresholdHigh;

                public GainModeObj(GainModeRoi sysGainModeROI, GainModeThresholds sysGainModeThresholds, ushort sysGainRoiPopulation, ushort sysGainModeTempEnabled, ushort sysGainModeFluxThresholdLow, ushort sysGainModeFluxThresholdHigh);

                public override string ToString();
            }
            public class CustSerialNumber
            {
                public sbyte[] value;

                public CustSerialNumber(sbyte[] value);

                public override string ToString();
            }
            public class Status
            {
                public SystemStatusStates camStatus;
                public ushort commandCount;
                public ushort reserved;

                public Status(SystemStatusStates camStatus, ushort commandCount, ushort reserved);

                public override string ToString();
            }
            public class SceneStatistics
            {
                public ushort meanIntensity;
                public ushort maxIntensity;
                public ushort minIntensity;
                public ushort numPixels;

                public SceneStatistics(ushort meanIntensity, ushort maxIntensity, ushort minIntensity, ushort numPixels);

                public override string ToString();
            }
            public class BadPixel
            {
                public byte row;
                public byte col;
                public byte value;
                public byte value2;

                public BadPixel(byte row, byte col, byte value, byte value2);

                public override string ToString();
            }
            public class VideoRoi
            {
                public ushort startCol;
                public ushort startRow;
                public ushort endCol;
                public ushort endRow;

                public VideoRoi(ushort startCol, ushort startRow, ushort endCol, ushort endRow);

                public override string ToString();
            }
            public class FfcShutterModeObj
            {
                public FfcShutterMode shutterMode;
                public ShutterTempLockoutState tempLockoutState;
                public Enable videoFreezeDuringFFC;
                public Enable ffcDesired;
                public uint elapsedTimeSinceLastFfc;
                public uint desiredFfcPeriod;
                public bool explicitCmdToOpen;
                public ushort desiredFfcTempDelta;
                public ushort imminentDelay;

                public FfcShutterModeObj(FfcShutterMode shutterMode, ShutterTempLockoutState tempLockoutState, Enable videoFreezeDuringFFC, Enable ffcDesired, uint elapsedTimeSinceLastFfc, uint desiredFfcPeriod, bool explicitCmdToOpen, ushort desiredFfcTempDelta, ushort imminentDelay);

                public override string ToString();
            }
            public class GainModeRoi
            {
                public ushort startCol;
                public ushort startRow;
                public ushort endCol;
                public ushort endRow;

                public GainModeRoi(ushort startCol, ushort startRow, ushort endCol, ushort endRow);

                public override string ToString();
            }
            public class GainModeThresholds
            {
                public ushort sys_P_high_to_low;
                public ushort sys_P_low_to_high;
                public ushort sys_C_high_to_low;
                public ushort sys_C_low_to_high;
                public ushort sys_T_high_to_low;
                public ushort sys_T_low_to_high;

                public GainModeThresholds(ushort sys_P_high_to_low, ushort sys_P_low_to_high, ushort sys_C_high_to_low, ushort sys_C_low_to_high, ushort sys_T_high_to_low, ushort sys_T_low_to_high);

                public override string ToString();
            }
            public class BoresightValues
            {
                public ushort targetRow;
                public ushort targetCol;
                public short targetRotation;
                public short fovX;
                public short fovY;

                public BoresightValues(ushort targetRow, ushort targetCol, short targetRotation, short fovX, short fovY);

                public override string ToString();
            }
        }
        public class LepErrorI2cArbitrationLost : LepErrorI2c
        {
            public LepErrorI2cArbitrationLost();
        }
        public class LepErrorI2cNackReceived : LepErrorI2c
        {
            public LepErrorI2cNackReceived();
        }
        //
        // Сводка:
        //     This module provides command and control of the video data. Selection of the
        //     video polarity (white-hot or black-hot), video output color look-up table, and
        //     access to reading the focus metric are available through this module.
        public class Vid
        {
            public Vid(UVC port);

            public BoresightCalcEnableState GetBoresightCalcEnableState();
            public BoresightCalcEnableState GetBoresightCalcEnableStateChecked();
            public BoresightCoordinates GetBoresightCoordinates();
            public BoresightCoordinates GetBoresightCoordinatesChecked();
            //
            // Сводка:
            //     VID Focus Calculation Enable State
            //     The camera can calculate a video scene focus metric (also useful as a metric
            //     of contrast). This function specifies whether or not the camera is to make these
            //     calculations on the input video. When enabled, the camera will calculate the
            //     video scene focus metric on each frame processed and make the result available
            //     in the focus metric. See section 4.5.6. When disabled, the camera does not execute
            //     the focus metric calculation.
            //     Note that AGC (See 4.4.1) must be disabled when the focus metric is enabled.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_FOCUS_CALC_DISABLE – LEP_VID_FOCUS_CALC_ENABLE – LEP_VID_FOCUS_CALC_DISABLE
            //     – N/A – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x0C
            //     With Set 0x0D
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFocusCalcEnableState() – Updates vidEnableFocusCalcStatePtr
            //     with the Camera’s current video focus calculation enable state. –
            //     All Lepton Configurations – LEP_SetVidFocusCalcEnableState() – Updates the Camera’s
            //     current video focus calculation enable state with the contents of vidFocusCalcEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFocusCalcEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     vidEnableFocusCalcStatePtr) LEP_RESULT LEP_SetVidFocusCalcEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, vidFocusCalcEnableState) /* Video Focus Metric Calculation Enable
            //     Enum */ typedef enum LEP_VID_ENABLE_TAG { LEP_VID_FOCUS_CALC_DISABLE=0, LEP_VID_FOCUS_CALC_ENABLE,
            //     LEP_VID_END_FOCUS_CALC_ENABLE }LEP_VID_FOCUS_CALC_ENABLE_E, *LEP_VID_FOCUS_CALC_ENABLE_E_PTR;
            public FocusCalcEnable GetFocusCalcEnableState();
            //
            // Сводка:
            //     VID Focus Calculation Enable State
            //     The camera can calculate a video scene focus metric (also useful as a metric
            //     of contrast). This function specifies whether or not the camera is to make these
            //     calculations on the input video. When enabled, the camera will calculate the
            //     video scene focus metric on each frame processed and make the result available
            //     in the focus metric. See section 4.5.6. When disabled, the camera does not execute
            //     the focus metric calculation.
            //     Note that AGC (See 4.4.1) must be disabled when the focus metric is enabled.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_FOCUS_CALC_DISABLE – LEP_VID_FOCUS_CALC_ENABLE – LEP_VID_FOCUS_CALC_DISABLE
            //     – N/A – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x0C
            //     With Set 0x0D
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFocusCalcEnableState() – Updates vidEnableFocusCalcStatePtr
            //     with the Camera’s current video focus calculation enable state. –
            //     All Lepton Configurations – LEP_SetVidFocusCalcEnableState() – Updates the Camera’s
            //     current video focus calculation enable state with the contents of vidFocusCalcEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFocusCalcEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     vidEnableFocusCalcStatePtr) LEP_RESULT LEP_SetVidFocusCalcEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, vidFocusCalcEnableState) /* Video Focus Metric Calculation Enable
            //     Enum */ typedef enum LEP_VID_ENABLE_TAG { LEP_VID_FOCUS_CALC_DISABLE=0, LEP_VID_FOCUS_CALC_ENABLE,
            //     LEP_VID_END_FOCUS_CALC_ENABLE }LEP_VID_FOCUS_CALC_ENABLE_E, *LEP_VID_FOCUS_CALC_ENABLE_E_PTR;
            public FocusCalcEnable GetFocusCalcEnableStateChecked();
            //
            // Сводка:
            //     VID Focus Metric
            //     This function returns the most recently calculated scene focus metric. The focus
            //     metric calculation counts image gradients that exceed the focus metric threshold.
            //     Larger values imply better scene focus due the presence of more large gradients.
            //     The focus metric is not defined if the video scene focus metric calculations
            //     are not enabled. . The focus metric uses the Tenengrad method, an edge-based
            //     metric that measures the sum of the horizontal and vertical gradients using Sobel
            //     operators. The focus metric threshold is applied to the sum of gradients. Gradients
            //     that exceed this threshold are then summed and counted and the Focus metric is
            //     computed from these.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 4294967295 – N/A – none – 1 –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x18
            //     SDK Data Length: Get 2 size of LEP_VID_FOCUS_METRIC_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFocusMetric() – Updates vidFocusMetricPtr
            //     with the Camera’s current video focus value. Not defined if focus calculation
            //     is not enabled. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFocusMetric(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_VID_FOCUS_METRIC_T_PTR
            //     vidFocusMetricPtr) typedef LEP_UINT32 LEP_VID_FOCUS_METRIC_T, *LEP_VID_FOCUS_METRIC_T_PTR;
            public uint GetFocusMetric();
            //
            // Сводка:
            //     VID Focus Metric
            //     This function returns the most recently calculated scene focus metric. The focus
            //     metric calculation counts image gradients that exceed the focus metric threshold.
            //     Larger values imply better scene focus due the presence of more large gradients.
            //     The focus metric is not defined if the video scene focus metric calculations
            //     are not enabled. . The focus metric uses the Tenengrad method, an edge-based
            //     metric that measures the sum of the horizontal and vertical gradients using Sobel
            //     operators. The focus metric threshold is applied to the sum of gradients. Gradients
            //     that exceed this threshold are then summed and counted and the Focus metric is
            //     computed from these.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 4294967295 – N/A – none – 1 –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x18
            //     SDK Data Length: Get 2 size of LEP_VID_FOCUS_METRIC_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFocusMetric() – Updates vidFocusMetricPtr
            //     with the Camera’s current video focus value. Not defined if focus calculation
            //     is not enabled. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFocusMetric(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_VID_FOCUS_METRIC_T_PTR
            //     vidFocusMetricPtr) typedef LEP_UINT32 LEP_VID_FOCUS_METRIC_T, *LEP_VID_FOCUS_METRIC_T_PTR;
            public uint GetFocusMetricChecked();
            //
            // Сводка:
            //     VID Focus Metric Threshold
            //     This function specifies the focus metric threshold. The focus metric evaluates
            //     image gradients and counts the number of gradient magnitudes that exceed the
            //     focus metric threshold. Therefore, larger values of the threshold imply the focus
            //     metric is counting gradients with larger magnitudes in effect filtering out small
            //     gradients in the image (pixel noise, for example). The Focus Metric uses the
            //     Tenengrad method which is an edge-based metric that measures the sum of the horizontal
            //     and vertical gradients using Sobel operators. The Focus Metric Threshold is applied
            //     to the sum of gradients. Gradients that exceed this threshold are then summed
            //     and counted and the Focus metric is computed from these.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 4294967295 – 30 – N/A – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x14
            //     With Set 0x15
            //     SDK Data Length: Get 2 size of LEP_VID_FOCUS_METRIC_THRESHOLD_T data type
            //     Set 2 size of LEP_VID_FOCUS_METRIC_THRESHOLD_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFocusMetricThreshold() – Updates vidFocusMetricThresholdPtr
            //     with the Camera’s current video focus metric threshold. –
            //     All Lepton Configurations – LEP_SetVidFocusMetricThreshold() – Updates the Camera’s
            //     current video focus metric threshold with the contents of vidFocusMetricThreshold.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFocusMetricThreshold(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_VID_FOCUS_METRIC_THRESHOLD_T_PTR vidFocusMetricThresholdPtr) LEP_RESULT LEP_SetVidFocusMetricThreshold(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_VID_FOCUS_METRIC_THRESHOLD_T vidFocusMetricThreshold) typedef
            //     LEP_UINT32 LEP_VID_FOCUS_METRIC_THRESHOLD_T, *LEP_VID_FOCUS_METRIC_THRESHOLD_T_PTR;
            public uint GetFocusMetricThreshold();
            //
            // Сводка:
            //     VID Focus Metric Threshold
            //     This function specifies the focus metric threshold. The focus metric evaluates
            //     image gradients and counts the number of gradient magnitudes that exceed the
            //     focus metric threshold. Therefore, larger values of the threshold imply the focus
            //     metric is counting gradients with larger magnitudes in effect filtering out small
            //     gradients in the image (pixel noise, for example). The Focus Metric uses the
            //     Tenengrad method which is an edge-based metric that measures the sum of the horizontal
            //     and vertical gradients using Sobel operators. The Focus Metric Threshold is applied
            //     to the sum of gradients. Gradients that exceed this threshold are then summed
            //     and counted and the Focus metric is computed from these.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 4294967295 – 30 – N/A – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x14
            //     With Set 0x15
            //     SDK Data Length: Get 2 size of LEP_VID_FOCUS_METRIC_THRESHOLD_T data type
            //     Set 2 size of LEP_VID_FOCUS_METRIC_THRESHOLD_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFocusMetricThreshold() – Updates vidFocusMetricThresholdPtr
            //     with the Camera’s current video focus metric threshold. –
            //     All Lepton Configurations – LEP_SetVidFocusMetricThreshold() – Updates the Camera’s
            //     current video focus metric threshold with the contents of vidFocusMetricThreshold.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFocusMetricThreshold(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_VID_FOCUS_METRIC_THRESHOLD_T_PTR vidFocusMetricThresholdPtr) LEP_RESULT LEP_SetVidFocusMetricThreshold(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_VID_FOCUS_METRIC_THRESHOLD_T vidFocusMetricThreshold) typedef
            //     LEP_UINT32 LEP_VID_FOCUS_METRIC_THRESHOLD_T, *LEP_VID_FOCUS_METRIC_THRESHOLD_T_PTR;
            public uint GetFocusMetricThresholdChecked();
            //
            // Сводка:
            //     VID Video Freeze Enable State
            //     This function allows the current frame to be repeated in lieu of a live video
            //     stream. When enabled, live video is halted from the camera. When disabled, live
            //     video resumes.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_FREEZE_DISABLE – LEP_VID_FREEZE_ENABLE – LEP_VID_FREEZE_DISABLE – N/A
            //     – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFreezeEnableState() – Updates vidFreezeEnableStatePtr
            //     with the Camera’s current Video Freeze enable state –
            //     All Lepton Configurations – LEP_SetVidFreezeEnableState() – Updates the Camera’s
            //     current Video Freeze enable state with the contents of vidFreezeEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFreezeEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_VID_FREEZE_ENABLE_E_PTR vidFreezeEnableStatePtr) LEP_RESULT LEP_SetVidFreezeEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_VID_FREEZE_ENABLE_E vidFreezeEnableState) /* Video Freeze Output
            //     Enable Enum */ typedef enum LEP_VID_FREEZE_ENABLE_TAG { LEP_VID_FREEZE_DISABLE
            //     = 0, LEP_VID_FREEZE_ENABLE, LEP_VID_END_FREEZE_ENABLE }LEP_VID_FREEZE_ENABLE_E,
            //     *LEP_VID_FREEZE_ENABLE_E_PTR ;
            public FreezeEnable GetFreezeEnableState();
            //
            // Сводка:
            //     VID Video Freeze Enable State
            //     This function allows the current frame to be repeated in lieu of a live video
            //     stream. When enabled, live video is halted from the camera. When disabled, live
            //     video resumes.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_FREEZE_DISABLE – LEP_VID_FREEZE_ENABLE – LEP_VID_FREEZE_DISABLE – N/A
            //     – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFreezeEnableState() – Updates vidFreezeEnableStatePtr
            //     with the Camera’s current Video Freeze enable state –
            //     All Lepton Configurations – LEP_SetVidFreezeEnableState() – Updates the Camera’s
            //     current Video Freeze enable state with the contents of vidFreezeEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFreezeEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_VID_FREEZE_ENABLE_E_PTR vidFreezeEnableStatePtr) LEP_RESULT LEP_SetVidFreezeEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_VID_FREEZE_ENABLE_E vidFreezeEnableState) /* Video Freeze Output
            //     Enable Enum */ typedef enum LEP_VID_FREEZE_ENABLE_TAG { LEP_VID_FREEZE_DISABLE
            //     = 0, LEP_VID_FREEZE_ENABLE, LEP_VID_END_FREEZE_ENABLE }LEP_VID_FREEZE_ENABLE_E,
            //     *LEP_VID_FREEZE_ENABLE_E_PTR ;
            public FreezeEnable GetFreezeEnableStateChecked();
            //
            // Сводка:
            //     VID Low Gain Pseudo-Color Look-Up Table Select
            //     This function allows selection of the video output pseudo-color LUT to be used
            //     when the camera is in Low Gain Mode. This LUT applies to the video processed
            //     by camera post AGC application before output. Color LUTs do not apply to raw
            //     video output of any format. Requires using the video output format of 24-bit
            //     R, G, B (See 4.6.7), AGC enabled and scaled to 8-bit output (See 4.4.1).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_GREYSCALE_LUT – LEP_VID_USER_LUT – LEP_VID_GREYSCALE_LUT – N/A – N/A
            //     –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x34
            //     With Set 0x35
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetVidLowGainPcolorLut() – Updates vidPcolorLutPtr with
            //     the Camera’s current video pseudo-color LUT selection. –
            //     Lepton 2.5, 3.5 – LEP_SetLowGainVidPcolorLut() – Sets Camera’s current video
            //     pseudo-color LUT selection to vidPcolorLut –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidLowGainPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_PCOLOR_LUT_E_PTR vidPcolorLutPtr) LEP_RESULT LEP_SetVidLowGainPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_PCOLOR_LUT_E vidPcolorLut) /* Video Pseudo-Color LUT Enum */
            //     typedef enum LEP_PCOLOR_LUT_E_TAG { LEP_VID_WHEEL6_LUT=0, LEP_VID_FUSION_LUT,
            //     LEP_VID_RAINBOW_LUT, LEP_VID_GLOBOW_LUT, LEP_VID_SEPIA_LUT, LEP_VID_COLOR_LUT,
            //     LEP_VID_ICE_FIRE_LUT, LEP_VID_RAIN_LUT, LEP_VID_USER_LUT, LEP_VID_END_PCOLOR_LUT
            //     }LEP_PCOLOR_LUT_E, *LEP_PCOLOR_LUT_E_PTR;
            public PcolorLut GetLowGainPcolorLut();
            //
            // Сводка:
            //     VID Low Gain Pseudo-Color Look-Up Table Select
            //     This function allows selection of the video output pseudo-color LUT to be used
            //     when the camera is in Low Gain Mode. This LUT applies to the video processed
            //     by camera post AGC application before output. Color LUTs do not apply to raw
            //     video output of any format. Requires using the video output format of 24-bit
            //     R, G, B (See 4.6.7), AGC enabled and scaled to 8-bit output (See 4.4.1).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_GREYSCALE_LUT – LEP_VID_USER_LUT – LEP_VID_GREYSCALE_LUT – N/A – N/A
            //     –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x34
            //     With Set 0x35
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetVidLowGainPcolorLut() – Updates vidPcolorLutPtr with
            //     the Camera’s current video pseudo-color LUT selection. –
            //     Lepton 2.5, 3.5 – LEP_SetLowGainVidPcolorLut() – Sets Camera’s current video
            //     pseudo-color LUT selection to vidPcolorLut –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidLowGainPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_PCOLOR_LUT_E_PTR vidPcolorLutPtr) LEP_RESULT LEP_SetVidLowGainPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_PCOLOR_LUT_E vidPcolorLut) /* Video Pseudo-Color LUT Enum */
            //     typedef enum LEP_PCOLOR_LUT_E_TAG { LEP_VID_WHEEL6_LUT=0, LEP_VID_FUSION_LUT,
            //     LEP_VID_RAINBOW_LUT, LEP_VID_GLOBOW_LUT, LEP_VID_SEPIA_LUT, LEP_VID_COLOR_LUT,
            //     LEP_VID_ICE_FIRE_LUT, LEP_VID_RAIN_LUT, LEP_VID_USER_LUT, LEP_VID_END_PCOLOR_LUT
            //     }LEP_PCOLOR_LUT_E, *LEP_PCOLOR_LUT_E_PTR;
            public PcolorLut GetLowGainPcolorLutChecked();
            //
            // Сводка:
            //     VID Pseudo-Color Look-Up Table Select
            //     This function allows selection of the video output pseudo-color LUT. This LUT
            //     applies to the video processed by camera post AGC application before output.
            //     Color LUTs do not apply to raw video output of any format. Requires using the
            //     video output format of 24-bit R, G, B (See 4.6.7), AGC enabled and scaled to
            //     8-bit output (See 4.4.1).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_GREYSCALE_LUT – LEP_VID_USER_LUT – LEP_VID_GREYSCALE_LUT – N/A – N/A
            //     –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x04
            //     With Set 0x05
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidPcolorLut() – Updates vidPcolorLutPtr with
            //     the Camera’s current video pseudo-color LUT selection. –
            //     All Lepton Configurations – LEP_SetVidPcolorLut() – Sets Camera’s current video
            //     pseudo-color LUT selection to vidPcolorLut –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_PCOLOR_LUT_E_PTR
            //     vidPcolorLutPtr) LEP_RESULT LEP_SetVidPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_PCOLOR_LUT_E vidPcolorLut) /* Video Pseudo-Color LUT Enum */ typedef enum
            //     LEP_PCOLOR_LUT_E_TAG { LEP_VID_WHEEL6_LUT=0, LEP_VID_FUSION_LUT, LEP_VID_RAINBOW_LUT,
            //     LEP_VID_GLOBOW_LUT, LEP_VID_SEPIA_LUT, LEP_VID_COLOR_LUT, LEP_VID_ICE_FIRE_LUT,
            //     LEP_VID_RAIN_LUT, LEP_VID_USER_LUT, LEP_VID_END_PCOLOR_LUT }LEP_PCOLOR_LUT_E,
            //     *LEP_PCOLOR_LUT_E_PTR;
            public PcolorLut GetPcolorLut();
            //
            // Сводка:
            //     VID Pseudo-Color Look-Up Table Select
            //     This function allows selection of the video output pseudo-color LUT. This LUT
            //     applies to the video processed by camera post AGC application before output.
            //     Color LUTs do not apply to raw video output of any format. Requires using the
            //     video output format of 24-bit R, G, B (See 4.6.7), AGC enabled and scaled to
            //     8-bit output (See 4.4.1).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_GREYSCALE_LUT – LEP_VID_USER_LUT – LEP_VID_GREYSCALE_LUT – N/A – N/A
            //     –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x04
            //     With Set 0x05
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidPcolorLut() – Updates vidPcolorLutPtr with
            //     the Camera’s current video pseudo-color LUT selection. –
            //     All Lepton Configurations – LEP_SetVidPcolorLut() – Sets Camera’s current video
            //     pseudo-color LUT selection to vidPcolorLut –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_PCOLOR_LUT_E_PTR
            //     vidPcolorLutPtr) LEP_RESULT LEP_SetVidPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_PCOLOR_LUT_E vidPcolorLut) /* Video Pseudo-Color LUT Enum */ typedef enum
            //     LEP_PCOLOR_LUT_E_TAG { LEP_VID_WHEEL6_LUT=0, LEP_VID_FUSION_LUT, LEP_VID_RAINBOW_LUT,
            //     LEP_VID_GLOBOW_LUT, LEP_VID_SEPIA_LUT, LEP_VID_COLOR_LUT, LEP_VID_ICE_FIRE_LUT,
            //     LEP_VID_RAIN_LUT, LEP_VID_USER_LUT, LEP_VID_END_PCOLOR_LUT }LEP_PCOLOR_LUT_E,
            //     *LEP_PCOLOR_LUT_E_PTR;
            public PcolorLut GetPcolorLutChecked();
            public Polarity GetPolarity();
            public Polarity GetPolarityChecked();
            public FocusRoi GetROI();
            public FocusRoi GetROIChecked();
            public SbnucEnable GetSbNucEnableState();
            public SbnucEnable GetSbNucEnableStateChecked();
            public TargetPosition GetTargetPosition();
            public TargetPosition GetTargetPositionChecked();
            //
            // Сводка:
            //     VID User Pseudo-Color Look-Up Table Upload/Download
            //     This function allows uploading (SET to the camera), and downloading (GET from
            //     the camera) a user-defined video output pseudo-color LUT. This LUT applies to
            //     the video processed by camera post AGC application before output. Does not apply
            //     to raw video output. The format of the pseudo-color LUT is 256 x 32-bits.
            //
            // Примечания:
            //     Parameter – Minimum Value – Maximum Value – Default Setting – Units – Scale factor
            //     –
            //     reserved – 0 – 0 – N/A – N/A – 1 –
            //     red – 0 – 255 – N/A – N/A – 1 –
            //     green – 0 – 255 – N/A – N/A – 1 –
            //     blue – 0 – 255 – N/A – N/A – 1 –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x08
            //     With Set 0x09
            //     SDK Data Length: Get 512 size of LEP_VID_LUT_BUFFER_T data type
            //     Set 512 size of LEP_VID_LUT_BUFFER_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidUserLut() – Updates vidUserLutBufPtr with
            //     the Camera’s current user-defined video pseudo-color LUT data. Length of the
            //     LUT is 1024 bytes supporting a 256 x 32-bit LUT format and passed as value in
            //     vidUserLutBufLen. –
            //     All Lepton Configurations – LEP_SetVidUserLut() – Updates the Camera’s current
            //     user-defined video pseudo-color LUT data with the contents of vidUserLutBufPtr.
            //     Length of the LUT is 1024 bytes supporting 256 x 32-bit LUT format and passed
            //     as value in vidUserLutBufLen. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidUserLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_UINT8
            //     *vidUserLutBufPtr, LEP_UINT16 vidUserLutBufLen) LEP_RESULT LEP_SetVidUserLut(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT8 *vidUserLutBufPtr, LEP_UINT16 vidUserLutBufLen) /* User-Defined
            //     color look-up table (LUT) */ typedef struct LEP_VID_LUT_PIXEL_T_TAG { LEP_UINT8
            //     reserved; LEP_UINT8 red; LEP_UINT8 green; LEP_UINT8 blue; } LEP_VID_LUT_PIXEL_T,
            //     *LEP_VID_LUT_PIXEL_T_PTR; typedef struct LEP_VID_LUT_BUFFER_T_TAG { LEP_VID_LUT_PIXEL_T
            //     bin[256]; } LEP_VID_LUT_BUFFER_T, *LEP_VID_LUT_BUFFER_T_PTR;
            public LutBuffer GetUserLut();
            //
            // Сводка:
            //     VID User Pseudo-Color Look-Up Table Upload/Download
            //     This function allows uploading (SET to the camera), and downloading (GET from
            //     the camera) a user-defined video output pseudo-color LUT. This LUT applies to
            //     the video processed by camera post AGC application before output. Does not apply
            //     to raw video output. The format of the pseudo-color LUT is 256 x 32-bits.
            //
            // Примечания:
            //     Parameter – Minimum Value – Maximum Value – Default Setting – Units – Scale factor
            //     –
            //     reserved – 0 – 0 – N/A – N/A – 1 –
            //     red – 0 – 255 – N/A – N/A – 1 –
            //     green – 0 – 255 – N/A – N/A – 1 –
            //     blue – 0 – 255 – N/A – N/A – 1 –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x08
            //     With Set 0x09
            //     SDK Data Length: Get 512 size of LEP_VID_LUT_BUFFER_T data type
            //     Set 512 size of LEP_VID_LUT_BUFFER_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidUserLut() – Updates vidUserLutBufPtr with
            //     the Camera’s current user-defined video pseudo-color LUT data. Length of the
            //     LUT is 1024 bytes supporting a 256 x 32-bit LUT format and passed as value in
            //     vidUserLutBufLen. –
            //     All Lepton Configurations – LEP_SetVidUserLut() – Updates the Camera’s current
            //     user-defined video pseudo-color LUT data with the contents of vidUserLutBufPtr.
            //     Length of the LUT is 1024 bytes supporting 256 x 32-bit LUT format and passed
            //     as value in vidUserLutBufLen. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidUserLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_UINT8
            //     *vidUserLutBufPtr, LEP_UINT16 vidUserLutBufLen) LEP_RESULT LEP_SetVidUserLut(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT8 *vidUserLutBufPtr, LEP_UINT16 vidUserLutBufLen) /* User-Defined
            //     color look-up table (LUT) */ typedef struct LEP_VID_LUT_PIXEL_T_TAG { LEP_UINT8
            //     reserved; LEP_UINT8 red; LEP_UINT8 green; LEP_UINT8 blue; } LEP_VID_LUT_PIXEL_T,
            //     *LEP_VID_LUT_PIXEL_T_PTR; typedef struct LEP_VID_LUT_BUFFER_T_TAG { LEP_VID_LUT_PIXEL_T
            //     bin[256]; } LEP_VID_LUT_BUFFER_T, *LEP_VID_LUT_BUFFER_T_PTR;
            public LutBuffer GetUserLutChecked();
            //
            // Сводка:
            //     VID Video Output Format
            //     This function provides the method to specify or retrieve the current video output
            //     format. In the current revision, only RGB888 and RAW14 are valid formats.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8 – LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_6 – LEP_VID_VIDEO_OUTPUT_FORMAT_RAW14
            //     – N/A – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x30
            //     With Set 0x31
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetVidVideoOutputFormat() – Updates vidVideoOutputFormatPtr
            //     with the Camera’s current video ouput format –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetVidVideoOutputFormat() – Updates the Camera’s Camera’s
            //     current video ouput format with the contents of vidVideoOutputFormat. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidVideoOutputFormat( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_E_PTR vidVideoOutputFormatPtr ) LEP_RESULT LEP_SetVidVideoOutputFormat(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_VID_VIDEO_OUTPUT_FORMAT_E vidVideoOutputFormat
            //     ) /* Video Output Format */ typedef struct LEP_VID_VIDEO_OUTPUT_FORMAT_TAG {
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8 = 0, // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW10,
            //     // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW12, // To
            //     be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RGB888, // To be supported
            //     in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RGB666, // To be supported in later
            //     release LEP_VID_VIDEO_OUTPUT_FORMAT_RGB565, // To be supported in later release
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_YUV422_8BIT, // To be supported in later release
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW14, // SUPPORTED in this release LEP_VID_VIDEO_OUTPUT_FORMAT_YUV422_10BIT,
            //     // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_USER_DEFINED,
            //     // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_2, // To
            //     be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_3, // To be supported
            //     in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_4, // To be supported in later
            //     release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_5, // To be supported in later release
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_6, // To be supported in later release LEP_END_VID_VIDEO_OUTPUT_FORMAT
            //     }LEP_VID_VIDEO_OUTPUT_FORMAT_E, *LEP_VID_VIDEO_OUTPUT_FORMAT_E_PTR;
            public VideoOutputFormat GetVideoOutputFormat();
            //
            // Сводка:
            //     VID Video Output Format
            //     This function provides the method to specify or retrieve the current video output
            //     format. In the current revision, only RGB888 and RAW14 are valid formats.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8 – LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_6 – LEP_VID_VIDEO_OUTPUT_FORMAT_RAW14
            //     – N/A – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x30
            //     With Set 0x31
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetVidVideoOutputFormat() – Updates vidVideoOutputFormatPtr
            //     with the Camera’s current video ouput format –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetVidVideoOutputFormat() – Updates the Camera’s Camera’s
            //     current video ouput format with the contents of vidVideoOutputFormat. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidVideoOutputFormat( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_E_PTR vidVideoOutputFormatPtr ) LEP_RESULT LEP_SetVidVideoOutputFormat(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_VID_VIDEO_OUTPUT_FORMAT_E vidVideoOutputFormat
            //     ) /* Video Output Format */ typedef struct LEP_VID_VIDEO_OUTPUT_FORMAT_TAG {
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8 = 0, // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW10,
            //     // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW12, // To
            //     be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RGB888, // To be supported
            //     in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RGB666, // To be supported in later
            //     release LEP_VID_VIDEO_OUTPUT_FORMAT_RGB565, // To be supported in later release
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_YUV422_8BIT, // To be supported in later release
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW14, // SUPPORTED in this release LEP_VID_VIDEO_OUTPUT_FORMAT_YUV422_10BIT,
            //     // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_USER_DEFINED,
            //     // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_2, // To
            //     be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_3, // To be supported
            //     in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_4, // To be supported in later
            //     release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_5, // To be supported in later release
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_6, // To be supported in later release LEP_END_VID_VIDEO_OUTPUT_FORMAT
            //     }LEP_VID_VIDEO_OUTPUT_FORMAT_E, *LEP_VID_VIDEO_OUTPUT_FORMAT_E_PTR;
            public VideoOutputFormat GetVideoOutputFormatChecked();
            public void SetBoresightCalcEnableState(BoresightCalcEnableState source);
            public void SetBoresightCalcEnableStateChecked(BoresightCalcEnableState source);
            //
            // Сводка:
            //     VID Focus Calculation Enable State
            //     The camera can calculate a video scene focus metric (also useful as a metric
            //     of contrast). This function specifies whether or not the camera is to make these
            //     calculations on the input video. When enabled, the camera will calculate the
            //     video scene focus metric on each frame processed and make the result available
            //     in the focus metric. See section 4.5.6. When disabled, the camera does not execute
            //     the focus metric calculation.
            //     Note that AGC (See 4.4.1) must be disabled when the focus metric is enabled.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_FOCUS_CALC_DISABLE – LEP_VID_FOCUS_CALC_ENABLE – LEP_VID_FOCUS_CALC_DISABLE
            //     – N/A – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x0C
            //     With Set 0x0D
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFocusCalcEnableState() – Updates vidEnableFocusCalcStatePtr
            //     with the Camera’s current video focus calculation enable state. –
            //     All Lepton Configurations – LEP_SetVidFocusCalcEnableState() – Updates the Camera’s
            //     current video focus calculation enable state with the contents of vidFocusCalcEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFocusCalcEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     vidEnableFocusCalcStatePtr) LEP_RESULT LEP_SetVidFocusCalcEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, vidFocusCalcEnableState) /* Video Focus Metric Calculation Enable
            //     Enum */ typedef enum LEP_VID_ENABLE_TAG { LEP_VID_FOCUS_CALC_DISABLE=0, LEP_VID_FOCUS_CALC_ENABLE,
            //     LEP_VID_END_FOCUS_CALC_ENABLE }LEP_VID_FOCUS_CALC_ENABLE_E, *LEP_VID_FOCUS_CALC_ENABLE_E_PTR;
            public void SetFocusCalcEnableState(FocusCalcEnable source);
            //
            // Сводка:
            //     VID Focus Calculation Enable State
            //     The camera can calculate a video scene focus metric (also useful as a metric
            //     of contrast). This function specifies whether or not the camera is to make these
            //     calculations on the input video. When enabled, the camera will calculate the
            //     video scene focus metric on each frame processed and make the result available
            //     in the focus metric. See section 4.5.6. When disabled, the camera does not execute
            //     the focus metric calculation.
            //     Note that AGC (See 4.4.1) must be disabled when the focus metric is enabled.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_FOCUS_CALC_DISABLE – LEP_VID_FOCUS_CALC_ENABLE – LEP_VID_FOCUS_CALC_DISABLE
            //     – N/A – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x0C
            //     With Set 0x0D
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFocusCalcEnableState() – Updates vidEnableFocusCalcStatePtr
            //     with the Camera’s current video focus calculation enable state. –
            //     All Lepton Configurations – LEP_SetVidFocusCalcEnableState() – Updates the Camera’s
            //     current video focus calculation enable state with the contents of vidFocusCalcEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFocusCalcEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     vidEnableFocusCalcStatePtr) LEP_RESULT LEP_SetVidFocusCalcEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, vidFocusCalcEnableState) /* Video Focus Metric Calculation Enable
            //     Enum */ typedef enum LEP_VID_ENABLE_TAG { LEP_VID_FOCUS_CALC_DISABLE=0, LEP_VID_FOCUS_CALC_ENABLE,
            //     LEP_VID_END_FOCUS_CALC_ENABLE }LEP_VID_FOCUS_CALC_ENABLE_E, *LEP_VID_FOCUS_CALC_ENABLE_E_PTR;
            public void SetFocusCalcEnableStateChecked(FocusCalcEnable source);
            //
            // Сводка:
            //     VID Focus Metric Threshold
            //     This function specifies the focus metric threshold. The focus metric evaluates
            //     image gradients and counts the number of gradient magnitudes that exceed the
            //     focus metric threshold. Therefore, larger values of the threshold imply the focus
            //     metric is counting gradients with larger magnitudes in effect filtering out small
            //     gradients in the image (pixel noise, for example). The Focus Metric uses the
            //     Tenengrad method which is an edge-based metric that measures the sum of the horizontal
            //     and vertical gradients using Sobel operators. The Focus Metric Threshold is applied
            //     to the sum of gradients. Gradients that exceed this threshold are then summed
            //     and counted and the Focus metric is computed from these.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 4294967295 – 30 – N/A – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x14
            //     With Set 0x15
            //     SDK Data Length: Get 2 size of LEP_VID_FOCUS_METRIC_THRESHOLD_T data type
            //     Set 2 size of LEP_VID_FOCUS_METRIC_THRESHOLD_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFocusMetricThreshold() – Updates vidFocusMetricThresholdPtr
            //     with the Camera’s current video focus metric threshold. –
            //     All Lepton Configurations – LEP_SetVidFocusMetricThreshold() – Updates the Camera’s
            //     current video focus metric threshold with the contents of vidFocusMetricThreshold.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFocusMetricThreshold(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_VID_FOCUS_METRIC_THRESHOLD_T_PTR vidFocusMetricThresholdPtr) LEP_RESULT LEP_SetVidFocusMetricThreshold(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_VID_FOCUS_METRIC_THRESHOLD_T vidFocusMetricThreshold) typedef
            //     LEP_UINT32 LEP_VID_FOCUS_METRIC_THRESHOLD_T, *LEP_VID_FOCUS_METRIC_THRESHOLD_T_PTR;
            public void SetFocusMetricThreshold(uint source);
            //
            // Сводка:
            //     VID Focus Metric Threshold
            //     This function specifies the focus metric threshold. The focus metric evaluates
            //     image gradients and counts the number of gradient magnitudes that exceed the
            //     focus metric threshold. Therefore, larger values of the threshold imply the focus
            //     metric is counting gradients with larger magnitudes in effect filtering out small
            //     gradients in the image (pixel noise, for example). The Focus Metric uses the
            //     Tenengrad method which is an edge-based metric that measures the sum of the horizontal
            //     and vertical gradients using Sobel operators. The Focus Metric Threshold is applied
            //     to the sum of gradients. Gradients that exceed this threshold are then summed
            //     and counted and the Focus metric is computed from these.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     0 – 4294967295 – 30 – N/A – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x14
            //     With Set 0x15
            //     SDK Data Length: Get 2 size of LEP_VID_FOCUS_METRIC_THRESHOLD_T data type
            //     Set 2 size of LEP_VID_FOCUS_METRIC_THRESHOLD_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFocusMetricThreshold() – Updates vidFocusMetricThresholdPtr
            //     with the Camera’s current video focus metric threshold. –
            //     All Lepton Configurations – LEP_SetVidFocusMetricThreshold() – Updates the Camera’s
            //     current video focus metric threshold with the contents of vidFocusMetricThreshold.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFocusMetricThreshold(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_VID_FOCUS_METRIC_THRESHOLD_T_PTR vidFocusMetricThresholdPtr) LEP_RESULT LEP_SetVidFocusMetricThreshold(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_VID_FOCUS_METRIC_THRESHOLD_T vidFocusMetricThreshold) typedef
            //     LEP_UINT32 LEP_VID_FOCUS_METRIC_THRESHOLD_T, *LEP_VID_FOCUS_METRIC_THRESHOLD_T_PTR;
            public void SetFocusMetricThresholdChecked(uint source);
            //
            // Сводка:
            //     VID Video Freeze Enable State
            //     This function allows the current frame to be repeated in lieu of a live video
            //     stream. When enabled, live video is halted from the camera. When disabled, live
            //     video resumes.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_FREEZE_DISABLE – LEP_VID_FREEZE_ENABLE – LEP_VID_FREEZE_DISABLE – N/A
            //     – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFreezeEnableState() – Updates vidFreezeEnableStatePtr
            //     with the Camera’s current Video Freeze enable state –
            //     All Lepton Configurations – LEP_SetVidFreezeEnableState() – Updates the Camera’s
            //     current Video Freeze enable state with the contents of vidFreezeEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFreezeEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_VID_FREEZE_ENABLE_E_PTR vidFreezeEnableStatePtr) LEP_RESULT LEP_SetVidFreezeEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_VID_FREEZE_ENABLE_E vidFreezeEnableState) /* Video Freeze Output
            //     Enable Enum */ typedef enum LEP_VID_FREEZE_ENABLE_TAG { LEP_VID_FREEZE_DISABLE
            //     = 0, LEP_VID_FREEZE_ENABLE, LEP_VID_END_FREEZE_ENABLE }LEP_VID_FREEZE_ENABLE_E,
            //     *LEP_VID_FREEZE_ENABLE_E_PTR ;
            public void SetFreezeEnableState(FreezeEnable source);
            //
            // Сводка:
            //     VID Video Freeze Enable State
            //     This function allows the current frame to be repeated in lieu of a live video
            //     stream. When enabled, live video is halted from the camera. When disabled, live
            //     video resumes.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_FREEZE_DISABLE – LEP_VID_FREEZE_ENABLE – LEP_VID_FREEZE_DISABLE – N/A
            //     – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x24
            //     With Set 0x25
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidFreezeEnableState() – Updates vidFreezeEnableStatePtr
            //     with the Camera’s current Video Freeze enable state –
            //     All Lepton Configurations – LEP_SetVidFreezeEnableState() – Updates the Camera’s
            //     current Video Freeze enable state with the contents of vidFreezeEnableState.
            //     –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidFreezeEnableState(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_VID_FREEZE_ENABLE_E_PTR vidFreezeEnableStatePtr) LEP_RESULT LEP_SetVidFreezeEnableState(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_VID_FREEZE_ENABLE_E vidFreezeEnableState) /* Video Freeze Output
            //     Enable Enum */ typedef enum LEP_VID_FREEZE_ENABLE_TAG { LEP_VID_FREEZE_DISABLE
            //     = 0, LEP_VID_FREEZE_ENABLE, LEP_VID_END_FREEZE_ENABLE }LEP_VID_FREEZE_ENABLE_E,
            //     *LEP_VID_FREEZE_ENABLE_E_PTR ;
            public void SetFreezeEnableStateChecked(FreezeEnable source);
            //
            // Сводка:
            //     VID Low Gain Pseudo-Color Look-Up Table Select
            //     This function allows selection of the video output pseudo-color LUT to be used
            //     when the camera is in Low Gain Mode. This LUT applies to the video processed
            //     by camera post AGC application before output. Color LUTs do not apply to raw
            //     video output of any format. Requires using the video output format of 24-bit
            //     R, G, B (See 4.6.7), AGC enabled and scaled to 8-bit output (See 4.4.1).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_GREYSCALE_LUT – LEP_VID_USER_LUT – LEP_VID_GREYSCALE_LUT – N/A – N/A
            //     –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x34
            //     With Set 0x35
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetVidLowGainPcolorLut() – Updates vidPcolorLutPtr with
            //     the Camera’s current video pseudo-color LUT selection. –
            //     Lepton 2.5, 3.5 – LEP_SetLowGainVidPcolorLut() – Sets Camera’s current video
            //     pseudo-color LUT selection to vidPcolorLut –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidLowGainPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_PCOLOR_LUT_E_PTR vidPcolorLutPtr) LEP_RESULT LEP_SetVidLowGainPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_PCOLOR_LUT_E vidPcolorLut) /* Video Pseudo-Color LUT Enum */
            //     typedef enum LEP_PCOLOR_LUT_E_TAG { LEP_VID_WHEEL6_LUT=0, LEP_VID_FUSION_LUT,
            //     LEP_VID_RAINBOW_LUT, LEP_VID_GLOBOW_LUT, LEP_VID_SEPIA_LUT, LEP_VID_COLOR_LUT,
            //     LEP_VID_ICE_FIRE_LUT, LEP_VID_RAIN_LUT, LEP_VID_USER_LUT, LEP_VID_END_PCOLOR_LUT
            //     }LEP_PCOLOR_LUT_E, *LEP_PCOLOR_LUT_E_PTR;
            public void SetLowGainPcolorLut(PcolorLut source);
            //
            // Сводка:
            //     VID Low Gain Pseudo-Color Look-Up Table Select
            //     This function allows selection of the video output pseudo-color LUT to be used
            //     when the camera is in Low Gain Mode. This LUT applies to the video processed
            //     by camera post AGC application before output. Color LUTs do not apply to raw
            //     video output of any format. Requires using the video output format of 24-bit
            //     R, G, B (See 4.6.7), AGC enabled and scaled to 8-bit output (See 4.4.1).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_GREYSCALE_LUT – LEP_VID_USER_LUT – LEP_VID_GREYSCALE_LUT – N/A – N/A
            //     –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x34
            //     With Set 0x35
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.5 – LEP_GetVidLowGainPcolorLut() – Updates vidPcolorLutPtr with
            //     the Camera’s current video pseudo-color LUT selection. –
            //     Lepton 2.5, 3.5 – LEP_SetLowGainVidPcolorLut() – Sets Camera’s current video
            //     pseudo-color LUT selection to vidPcolorLut –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidLowGainPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_PCOLOR_LUT_E_PTR vidPcolorLutPtr) LEP_RESULT LEP_SetVidLowGainPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_PCOLOR_LUT_E vidPcolorLut) /* Video Pseudo-Color LUT Enum */
            //     typedef enum LEP_PCOLOR_LUT_E_TAG { LEP_VID_WHEEL6_LUT=0, LEP_VID_FUSION_LUT,
            //     LEP_VID_RAINBOW_LUT, LEP_VID_GLOBOW_LUT, LEP_VID_SEPIA_LUT, LEP_VID_COLOR_LUT,
            //     LEP_VID_ICE_FIRE_LUT, LEP_VID_RAIN_LUT, LEP_VID_USER_LUT, LEP_VID_END_PCOLOR_LUT
            //     }LEP_PCOLOR_LUT_E, *LEP_PCOLOR_LUT_E_PTR;
            public void SetLowGainPcolorLutChecked(PcolorLut source);
            //
            // Сводка:
            //     VID Pseudo-Color Look-Up Table Select
            //     This function allows selection of the video output pseudo-color LUT. This LUT
            //     applies to the video processed by camera post AGC application before output.
            //     Color LUTs do not apply to raw video output of any format. Requires using the
            //     video output format of 24-bit R, G, B (See 4.6.7), AGC enabled and scaled to
            //     8-bit output (See 4.4.1).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_GREYSCALE_LUT – LEP_VID_USER_LUT – LEP_VID_GREYSCALE_LUT – N/A – N/A
            //     –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x04
            //     With Set 0x05
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidPcolorLut() – Updates vidPcolorLutPtr with
            //     the Camera’s current video pseudo-color LUT selection. –
            //     All Lepton Configurations – LEP_SetVidPcolorLut() – Sets Camera’s current video
            //     pseudo-color LUT selection to vidPcolorLut –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_PCOLOR_LUT_E_PTR
            //     vidPcolorLutPtr) LEP_RESULT LEP_SetVidPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_PCOLOR_LUT_E vidPcolorLut) /* Video Pseudo-Color LUT Enum */ typedef enum
            //     LEP_PCOLOR_LUT_E_TAG { LEP_VID_WHEEL6_LUT=0, LEP_VID_FUSION_LUT, LEP_VID_RAINBOW_LUT,
            //     LEP_VID_GLOBOW_LUT, LEP_VID_SEPIA_LUT, LEP_VID_COLOR_LUT, LEP_VID_ICE_FIRE_LUT,
            //     LEP_VID_RAIN_LUT, LEP_VID_USER_LUT, LEP_VID_END_PCOLOR_LUT }LEP_PCOLOR_LUT_E,
            //     *LEP_PCOLOR_LUT_E_PTR;
            public void SetPcolorLut(PcolorLut source);
            //
            // Сводка:
            //     VID Pseudo-Color Look-Up Table Select
            //     This function allows selection of the video output pseudo-color LUT. This LUT
            //     applies to the video processed by camera post AGC application before output.
            //     Color LUTs do not apply to raw video output of any format. Requires using the
            //     video output format of 24-bit R, G, B (See 4.6.7), AGC enabled and scaled to
            //     8-bit output (See 4.4.1).
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_GREYSCALE_LUT – LEP_VID_USER_LUT – LEP_VID_GREYSCALE_LUT – N/A – N/A
            //     –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x04
            //     With Set 0x05
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidPcolorLut() – Updates vidPcolorLutPtr with
            //     the Camera’s current video pseudo-color LUT selection. –
            //     All Lepton Configurations – LEP_SetVidPcolorLut() – Sets Camera’s current video
            //     pseudo-color LUT selection to vidPcolorLut –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_PCOLOR_LUT_E_PTR
            //     vidPcolorLutPtr) LEP_RESULT LEP_SetVidPcolorLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_PCOLOR_LUT_E vidPcolorLut) /* Video Pseudo-Color LUT Enum */ typedef enum
            //     LEP_PCOLOR_LUT_E_TAG { LEP_VID_WHEEL6_LUT=0, LEP_VID_FUSION_LUT, LEP_VID_RAINBOW_LUT,
            //     LEP_VID_GLOBOW_LUT, LEP_VID_SEPIA_LUT, LEP_VID_COLOR_LUT, LEP_VID_ICE_FIRE_LUT,
            //     LEP_VID_RAIN_LUT, LEP_VID_USER_LUT, LEP_VID_END_PCOLOR_LUT }LEP_PCOLOR_LUT_E,
            //     *LEP_PCOLOR_LUT_E_PTR;
            public void SetPcolorLutChecked(PcolorLut source);
            public void SetPolarity(Polarity source);
            public void SetPolarityChecked(Polarity source);
            public void SetROI(FocusRoi source);
            public void SetROIChecked(FocusRoi source);
            public void SetSbNucEnableState(SbnucEnable source);
            public void SetSbNucEnableStateChecked(SbnucEnable source);
            //
            // Сводка:
            //     VID User Pseudo-Color Look-Up Table Upload/Download
            //     This function allows uploading (SET to the camera), and downloading (GET from
            //     the camera) a user-defined video output pseudo-color LUT. This LUT applies to
            //     the video processed by camera post AGC application before output. Does not apply
            //     to raw video output. The format of the pseudo-color LUT is 256 x 32-bits.
            //
            // Примечания:
            //     Parameter – Minimum Value – Maximum Value – Default Setting – Units – Scale factor
            //     –
            //     reserved – 0 – 0 – N/A – N/A – 1 –
            //     red – 0 – 255 – N/A – N/A – 1 –
            //     green – 0 – 255 – N/A – N/A – 1 –
            //     blue – 0 – 255 – N/A – N/A – 1 –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x08
            //     With Set 0x09
            //     SDK Data Length: Get 512 size of LEP_VID_LUT_BUFFER_T data type
            //     Set 512 size of LEP_VID_LUT_BUFFER_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidUserLut() – Updates vidUserLutBufPtr with
            //     the Camera’s current user-defined video pseudo-color LUT data. Length of the
            //     LUT is 1024 bytes supporting a 256 x 32-bit LUT format and passed as value in
            //     vidUserLutBufLen. –
            //     All Lepton Configurations – LEP_SetVidUserLut() – Updates the Camera’s current
            //     user-defined video pseudo-color LUT data with the contents of vidUserLutBufPtr.
            //     Length of the LUT is 1024 bytes supporting 256 x 32-bit LUT format and passed
            //     as value in vidUserLutBufLen. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidUserLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_UINT8
            //     *vidUserLutBufPtr, LEP_UINT16 vidUserLutBufLen) LEP_RESULT LEP_SetVidUserLut(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT8 *vidUserLutBufPtr, LEP_UINT16 vidUserLutBufLen) /* User-Defined
            //     color look-up table (LUT) */ typedef struct LEP_VID_LUT_PIXEL_T_TAG { LEP_UINT8
            //     reserved; LEP_UINT8 red; LEP_UINT8 green; LEP_UINT8 blue; } LEP_VID_LUT_PIXEL_T,
            //     *LEP_VID_LUT_PIXEL_T_PTR; typedef struct LEP_VID_LUT_BUFFER_T_TAG { LEP_VID_LUT_PIXEL_T
            //     bin[256]; } LEP_VID_LUT_BUFFER_T, *LEP_VID_LUT_BUFFER_T_PTR;
            public void SetUserLut(LutBuffer source);
            //
            // Сводка:
            //     VID User Pseudo-Color Look-Up Table Upload/Download
            //     This function allows uploading (SET to the camera), and downloading (GET from
            //     the camera) a user-defined video output pseudo-color LUT. This LUT applies to
            //     the video processed by camera post AGC application before output. Does not apply
            //     to raw video output. The format of the pseudo-color LUT is 256 x 32-bits.
            //
            // Примечания:
            //     Parameter – Minimum Value – Maximum Value – Default Setting – Units – Scale factor
            //     –
            //     reserved – 0 – 0 – N/A – N/A – 1 –
            //     red – 0 – 255 – N/A – N/A – 1 –
            //     green – 0 – 255 – N/A – N/A – 1 –
            //     blue – 0 – 255 – N/A – N/A – 1 –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x08
            //     With Set 0x09
            //     SDK Data Length: Get 512 size of LEP_VID_LUT_BUFFER_T data type
            //     Set 512 size of LEP_VID_LUT_BUFFER_T data type
            //     Compatibility – C-SDK Commands – Description –
            //     All Lepton Configurations – LEP_GetVidUserLut() – Updates vidUserLutBufPtr with
            //     the Camera’s current user-defined video pseudo-color LUT data. Length of the
            //     LUT is 1024 bytes supporting a 256 x 32-bit LUT format and passed as value in
            //     vidUserLutBufLen. –
            //     All Lepton Configurations – LEP_SetVidUserLut() – Updates the Camera’s current
            //     user-defined video pseudo-color LUT data with the contents of vidUserLutBufPtr.
            //     Length of the LUT is 1024 bytes supporting 256 x 32-bit LUT format and passed
            //     as value in vidUserLutBufLen. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidUserLut(LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_UINT8
            //     *vidUserLutBufPtr, LEP_UINT16 vidUserLutBufLen) LEP_RESULT LEP_SetVidUserLut(LEP_CAMERA_PORT_DESC_T_PTR
            //     portDescPtr, LEP_UINT8 *vidUserLutBufPtr, LEP_UINT16 vidUserLutBufLen) /* User-Defined
            //     color look-up table (LUT) */ typedef struct LEP_VID_LUT_PIXEL_T_TAG { LEP_UINT8
            //     reserved; LEP_UINT8 red; LEP_UINT8 green; LEP_UINT8 blue; } LEP_VID_LUT_PIXEL_T,
            //     *LEP_VID_LUT_PIXEL_T_PTR; typedef struct LEP_VID_LUT_BUFFER_T_TAG { LEP_VID_LUT_PIXEL_T
            //     bin[256]; } LEP_VID_LUT_BUFFER_T, *LEP_VID_LUT_BUFFER_T_PTR;
            public void SetUserLutChecked(LutBuffer source);
            //
            // Сводка:
            //     VID Video Output Format
            //     This function provides the method to specify or retrieve the current video output
            //     format. In the current revision, only RGB888 and RAW14 are valid formats.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8 – LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_6 – LEP_VID_VIDEO_OUTPUT_FORMAT_RAW14
            //     – N/A – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x30
            //     With Set 0x31
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetVidVideoOutputFormat() – Updates vidVideoOutputFormatPtr
            //     with the Camera’s current video ouput format –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetVidVideoOutputFormat() – Updates the Camera’s Camera’s
            //     current video ouput format with the contents of vidVideoOutputFormat. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidVideoOutputFormat( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_E_PTR vidVideoOutputFormatPtr ) LEP_RESULT LEP_SetVidVideoOutputFormat(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_VID_VIDEO_OUTPUT_FORMAT_E vidVideoOutputFormat
            //     ) /* Video Output Format */ typedef struct LEP_VID_VIDEO_OUTPUT_FORMAT_TAG {
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8 = 0, // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW10,
            //     // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW12, // To
            //     be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RGB888, // To be supported
            //     in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RGB666, // To be supported in later
            //     release LEP_VID_VIDEO_OUTPUT_FORMAT_RGB565, // To be supported in later release
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_YUV422_8BIT, // To be supported in later release
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW14, // SUPPORTED in this release LEP_VID_VIDEO_OUTPUT_FORMAT_YUV422_10BIT,
            //     // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_USER_DEFINED,
            //     // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_2, // To
            //     be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_3, // To be supported
            //     in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_4, // To be supported in later
            //     release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_5, // To be supported in later release
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_6, // To be supported in later release LEP_END_VID_VIDEO_OUTPUT_FORMAT
            //     }LEP_VID_VIDEO_OUTPUT_FORMAT_E, *LEP_VID_VIDEO_OUTPUT_FORMAT_E_PTR;
            public void SetVideoOutputFormat(VideoOutputFormat source);
            //
            // Сводка:
            //     VID Video Output Format
            //     This function provides the method to specify or retrieve the current video output
            //     format. In the current revision, only RGB888 and RAW14 are valid formats.
            //
            // Примечания:
            //     Minimum Value – Maximum Value – Default Setting – Units – Scale factor –
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8 – LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_6 – LEP_VID_VIDEO_OUTPUT_FORMAT_RAW14
            //     – N/A – N/A –
            //     SDK Module ID: VID 0x0300
            //     SDK Command ID: Base With Get 0x30
            //     With Set 0x31
            //     SDK Data Length: Get 2 size on an Enum data type on a 32-bit machine
            //     Set 2 size on an Enum data type on a 32-bit machine
            //     Compatibility – C-SDK Commands – Description –
            //     Lepton 2.5, 3.0, 3.5 – LEP_GetVidVideoOutputFormat() – Updates vidVideoOutputFormatPtr
            //     with the Camera’s current video ouput format –
            //     Lepton 2.5, 3.0, 3.5 – LEP_SetVidVideoOutputFormat() – Updates the Camera’s Camera’s
            //     current video ouput format with the contents of vidVideoOutputFormat. –
            //     C SDK Interface:
            //     LEP_RESULT LEP_GetVidVideoOutputFormat( LEP_CAMERA_PORT_DESC_T_PTR portDescPtr,
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_E_PTR vidVideoOutputFormatPtr ) LEP_RESULT LEP_SetVidVideoOutputFormat(
            //     LEP_CAMERA_PORT_DESC_T_PTR portDescPtr, LEP_VID_VIDEO_OUTPUT_FORMAT_E vidVideoOutputFormat
            //     ) /* Video Output Format */ typedef struct LEP_VID_VIDEO_OUTPUT_FORMAT_TAG {
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8 = 0, // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW10,
            //     // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW12, // To
            //     be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RGB888, // To be supported
            //     in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RGB666, // To be supported in later
            //     release LEP_VID_VIDEO_OUTPUT_FORMAT_RGB565, // To be supported in later release
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_YUV422_8BIT, // To be supported in later release
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW14, // SUPPORTED in this release LEP_VID_VIDEO_OUTPUT_FORMAT_YUV422_10BIT,
            //     // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_USER_DEFINED,
            //     // To be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_2, // To
            //     be supported in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_3, // To be supported
            //     in later release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_4, // To be supported in later
            //     release LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_5, // To be supported in later release
            //     LEP_VID_VIDEO_OUTPUT_FORMAT_RAW8_6, // To be supported in later release LEP_END_VID_VIDEO_OUTPUT_FORMAT
            //     }LEP_VID_VIDEO_OUTPUT_FORMAT_E, *LEP_VID_VIDEO_OUTPUT_FORMAT_E_PTR;
            public void SetVideoOutputFormatChecked(VideoOutputFormat source);

            public enum VideoOutputFormat
            {
                RAW8 = 0,
                RAW10 = 1,
                RAW12 = 2,
                RGB888 = 3,
                RGB666 = 4,
                RGB565 = 5,
                YUV422_8BIT = 6,
                RAW14 = 7,
                YUV422_10BIT = 8,
                USER_DEFINED = 9,
                RAW8_2 = 10,
                RAW8_3 = 11,
                RAW8_4 = 12,
                RAW8_5 = 13,
                RAW8_6 = 14
            }
            public enum BoresightCalcEnableState
            {
                BORESIGHT_CALC_DISABLED = 0,
                BORESIGHT_CALC_ENABLED = 1
            }
            public enum FreezeEnable
            {
                DISABLE = 0,
                ENABLE = 1
            }
            public enum Polarity
            {
                WHITE_HOT = 0,
                BLACK_HOT = 1
            }
            public enum FocusCalcEnable
            {
                DISABLE = 0,
                ENABLE = 1
            }
            public enum PcolorLut
            {
                WHEEL6_LUT = 0,
                FUSION_LUT = 1,
                RAINBOW_LUT = 2,
                GLOBOW_LUT = 3,
                SEPIA_LUT = 4,
                COLOR_LUT = 5,
                ICE_FIRE_LUT = 6,
                RAIN_LUT = 7,
                USER_LUT = 8
            }
            public enum SbnucEnable
            {
                DISABLE = 0,
                ENABLE = 1
            }

            public class BoresightCoordinates
            {
                public PixelCoordinate top_0;
                public PixelCoordinate top_1;
                public PixelCoordinate bottom_0;
                public PixelCoordinate bottom_1;
                public PixelCoordinate left_0;
                public PixelCoordinate left_1;
                public PixelCoordinate right_0;
                public PixelCoordinate right_1;

                public BoresightCoordinates(PixelCoordinate top_0, PixelCoordinate top_1, PixelCoordinate bottom_0, PixelCoordinate bottom_1, PixelCoordinate left_0, PixelCoordinate left_1, PixelCoordinate right_0, PixelCoordinate right_1);

                public override string ToString();
            }
            public class LutPixel
            {
                public byte reserved;
                public byte red;
                public byte green;
                public byte blue;

                public LutPixel(byte reserved, byte red, byte green, byte blue);

                public override string ToString();
            }
            public class LutBuffer
            {
                public LutPixel[] bin;

                public LutBuffer(LutPixel[] bin);

                public override string ToString();
            }
            public class FocusRoi
            {
                public ushort startCol;
                public ushort startRow;
                public ushort endCol;
                public ushort endRow;

                public FocusRoi(ushort startCol, ushort startRow, ushort endCol, ushort endRow);

                public override string ToString();
            }
            public class PixelCoordinate
            {
                public ushort row;
                public ushort col;

                public PixelCoordinate(ushort row, ushort col);

                public override string ToString();
            }
            public class TargetPosition
            {
                public float row;
                public float col;
                public float rotation;

                public TargetPosition(float row, float col, float rotation);

                public override string ToString();
            }
        }
    }
}