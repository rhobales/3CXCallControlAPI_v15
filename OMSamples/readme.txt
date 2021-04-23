3CXObjectModel.2.0.0.0_v15.chm - help file for Configuration and Call Control API V15
OMSamples - C# project files for VS2015 containing samples of how to use Configuration server and Call Control API.
If you cannot open the chm, right click > properties > and press Unblock button. 

#####################

Prerequisites:
1. Stanalone host.
2. User should have administrative rights.
3. Two applications installed on the the host:
a) Microsoft Visual Studio 2015 (.NET 4.6.1, C#)
b) Test installaion of 3CX Phone System version 15 SP1(or later) with activated demo or any other commercial license.
WARNING: DO NOT RUN SAMPLES ON PRODUCTION (LIVE) enviroment
4. Copy 3CXPhoneSystem.ini from C:\Program Files\3CX Phone System\Instance1\Bin to the same folder where Visual Studio will output the binary files. 


Usage:
	OMSamples [/?]|[SampleName arg1 arg2 ...]
List of samples:

SampleName: add_ivr
Implemented in OMSamples.Samples.AddIVRSample
Parameters:
	arg1 - System extension number of new Digital receptionist

Description: Creates Digital Receptionist 'TestIVR' which has empty prompt and redirects call to Voicemail of the extension after 20 seconds
--------------------------------------------------------------------------------
SampleName: bargein
Implemented in OMSamples.Samples.BargeInSample
Parameters:
	arg1 - Specifies extension which will barge in to the call.
	arg2 - Specifies extension which participate in a call

Description: Call Control API. Demostrates How to use PhoneSystem.BargeIn()
--------------------------------------------------------------------------------
SampleName: blacklist_monitor
Implemented in OMSamples.Samples.BlackListMonitor
Description: Sample of IP Black List manager
--------------------------------------------------------------------------------
SampleName: change_parkcodes
Implemented in OMSamples.Samples.ChangeParkCodesSample
WARNING: This sample changes global settings of PBX.
Parameters:
	arg1 - dial code to park call from the Parking Orbit
	arg2 - dial code to unpark call from the Parking Orbit

Description: Shows how to change dial codes of Parking Orbit
--------------------------------------------------------------------------------
SampleName: change_vmbox_info
Implemented in OMSamples.Samples.ChangeVMBoxInfoSample
Parameters:
	arg1 - extension number

Description: Sets voicemail box information for the specified extension. 
Number of messages is hardcoded and set to 1 new message and 2 messages in total.
--------------------------------------------------------------------------------
SampleName: create_delete_stat
Implemented in OMSamples.Samples.CreateDeleteStatSample
Description: This sample shows how to delete and create Statistics object. 
Statistics 'MYSTAT' should be initialized before runing this sample. 
(use update_stat sample)
--------------------------------------------------------------------------------
SampleName: create_fax_extension
Implemented in OMSamples.Samples.CreateFaxExtensionSample
Parameters:
	arg1 - System extension number for new FaxExtension
	arg2 - SIP authentication ID. It can be different form the FaxExtension number
	arg3 - Authentication password. must be secure

Description: Creates FAX extension.
--------------------------------------------------------------------------------
SampleName: create_prompt_set
Implemented in OMSamples.Samples.CreatePromptSetSample
Description: Synthetic sample. It shows how to configure PromptSet object.
--------------------------------------------------------------------------------
SampleName: create_shared_parking
Implemented in OMSamples.Samples.CreateSharedParkingSample
Parameters:
	arg1 - name of shared parking place

Description: This sample adds Shared parking place. The name MUST start with 'SP'.
--------------------------------------------------------------------------------
SampleName: display
Implemented in OMSamples.Samples.DisplayAllSample
Description: Shows information about all Parameters, Codecs, predefined conditions of the rules, IVRs and Extensions.
--------------------------------------------------------------------------------
SampleName: divertcall
Implemented in OMSamples.Samples.DivertCallSample
Parameters:
	arg1 - CallID taken from real active connection
	arg2 - Extension where call is ringing
	arg3 - new destination for the call
	arg4 -  optional. if '1' then call will be diverted to voicemail of the destination specified by arg3

Description: Shows how to use CallControl API to divert call.
--------------------------------------------------------------------------------
SampleName: dn_monitor
Implemented in OMSamples.Samples.DNmonitorSample
Description: Shows status of all DNs in the system(including active connections) and show all notifications about changes made in PBX configuration
--------------------------------------------------------------------------------
SampleName: dropcall
Implemented in OMSamples.Samples.DropCallSample
Parameters:
	arg1 - Specifies extension number

Description: Shows how to drop calls on specific extension using Call Control API
--------------------------------------------------------------------------------
SampleName: ext_line_rule_update
Implemented in OMSamples.Samples.ExternalLineRuleUpdateSample
WARNING: This sample will modify destination of existing rules. Line should be recreated after this test
Parameters:
	arg1 - Virtual extension number of the line

Description: This sample shows how to change destination of ExternalLineRule
--------------------------------------------------------------------------------
SampleName: invoke
Implemented in OMSamples.Samples.InvokeSample
Parameters:
	arg1 - command which should be invoked
	arg2, arg3 and so on - additional parameters for Invoke method - each additional parameter should be set as parameter_name=parameter_value

Description: Shows how to use PhoneSystem.Invoke() method
--------------------------------------------------------------------------------
SampleName: listen
Implemented in OMSamples.Samples.ListenSample
Parameters:
	arg1 - Specifies extension which will barge in to the call.
	arg2 - Specifies extension which participate in a call

Description: Shows how to use PhoneSystem.BargeIn to listen a call
--------------------------------------------------------------------------------
SampleName: makecall
Implemented in OMSamples.Samples.MakeCallSample
Parameters:
	arg1 - Source of the call
	arg2 - Destination of the call

Description: Shows how to use MakeCall helper. call will come to the source and after answer source will be transferred to destination number
--------------------------------------------------------------------------------
SampleName: makecall2
Implemented in OMSamples.Samples.MakeCall2Sample
Parameters:
	arg1 - Source of the call
	arg2, arg3 and so on - Additional parameters for the call. in form paramname=paramvalue

Description: Shows how to use extended version of PhoneSystem.MakeCall(string, Dictionary<string, string>) helper
--------------------------------------------------------------------------------
SampleName: notifications_monitor
Implemented in OMSamples.Samples.NotificationsMonitorSample
Parameters:
	arg1 - Object type name

Description: Shows update notifications of specified type of the objects. All notifications will be shown if arg1 is not specified
--------------------------------------------------------------------------------
SampleName: park_orbit_monitor
Implemented in OMSamples.Samples.ParkOrbitMonitorSample
Description: Monitors activity on Parking Orbit
--------------------------------------------------------------------------------
SampleName: phonebook
Implemented in OMSamples.Samples.PhoneBookSample
Description: Shows how to create PhoneBookEntry for company and personal phonebooks
--------------------------------------------------------------------------------
SampleName: dnproperty_save_delete
Implemented in OMSamples.Samples.DNPropertySaveDeleteSample
WARNING: modifies configuration of the extension specified by argument 1
Parameters:
	arg1 - Extension which will be modified

Description: Shows how to modify(add) and delete DNProperty. each time when script is running it created->modifies->deletes property of dn depending on its value
--------------------------------------------------------------------------------
SampleName: record_call
Implemented in OMSamples.Samples.RecordCallSample
Parameters:
	arg1 - CallID taken from ActiveConnection
	arg2 - who initiate record. (must be participant of the call
	arg3 - 1/0 - start/stop

Description: Shows how to start/stop recording of the call
--------------------------------------------------------------------------------
SampleName: recordivrprompt
Implemented in OMSamples.Samples.RecordIVRPrompt
Parameters:
	arg1 - IVR number
	arg2 - Extension number
	arg3 - (optional) name of the file. File will be stored in standard IVR prompt path and will be appended with .wav extension

Description: If IVR and extension exist, are not busy and extension is registered then PBX will contact extension to record file and will set it as a new prompt for the IVR
--------------------------------------------------------------------------------
SampleName: refresh_line_registration
Implemented in OMSamples.Samples.RefreshLineRegistrationSample
Parameters:
	arg1 - Virtual extension number of External Line

Description: Shows how to refresh registration on VoIP provider Line
--------------------------------------------------------------------------------
SampleName: remove_extension
Implemented in OMSamples.Samples.RemoveExtensionSample
WARNING: It is destructive operation. Please be carefull with arguments
Parameters:
	arg1 - extension number

Description: Shows how to remove existing extension
--------------------------------------------------------------------------------
SampleName: remove_ivr
Implemented in OMSamples.Samples.RemoveIVRSample
WARNING: It is destructive operation. Please be carefull with arguments
Parameters:
	arg1 - system extension number of IVR

Description: Shows how to remove existing IVR
--------------------------------------------------------------------------------
SampleName: set_multicast_paging
Implemented in OMSamples.Samples.SetMulticastPagingSample
Parameters:
	arg1 - Paging group
	arg2 - Multicast address
	arg3 - Multicast port
	arg4 - codec. (PCMU, PCMA, GSM, G729 etc..)
	arg5 - ptime for RTP packets. use 20

Description: Shows how to set 'multicast' options for paging group. If only arg1 is provided then multicast settings will be removed and paging group will work as in 'multicall' mode
--------------------------------------------------------------------------------
SampleName: set_office_hours
Implemented in OMSamples.Samples.SetOfficeHoursSample
WARNING: This sample modifies office hours on PBX and sets them to Monday-Friday 8:00 - 17:00 as office time, and 13:00-14:00 as office BreakTime
Description: Shows how to setup 'Office Hours' of PBX
--------------------------------------------------------------------------------
SampleName: set_outboundrule
Implemented in OMSamples.Samples.SetOutboundRuleSample
Description: Shows how to configure outbound rules. Requires at least one gateway configured on PBX.
--------------------------------------------------------------------------------
SampleName: show_gateway_parameters
Implemented in OMSamples.Samples.ShowGatewayParametersSample
Description: 
--------------------------------------------------------------------------------
SampleName: transfer_by_active_connection
Implemented in OMSamples.Samples.TransferByActiveConnectionSample
Parameters:
	arg1 - CallID taken from ActiveConnection
	arg2 - participant which will be replaced in the call
	arg3 - new participant who should replace participant specified by agr2

Description: Shows how to specify transfer call using ActiveConnection object. see PBXAPI.TransferCall()
--------------------------------------------------------------------------------
SampleName: transfer_by_dn
Implemented in OMSamples.Samples.TransferByDNSample
Parameters:
	arg1 - CallID taken from ActiveConnection
	arg2 - participant which will be replaced in the call
	arg3 - new participant who should replace participant specified by agr2

Description: Shows how to use PBXAPI.TransferCall()
--------------------------------------------------------------------------------
SampleName: update_extensions
Implemented in OMSamples.Samples.UpdateExtensionsSample
Description: Show how to update one of the Extension property for all extensions in the sysytem. This sample modifies 'PBX delivers audio' setting for all extensions
--------------------------------------------------------------------------------
SampleName: update_stat
Implemented in OMSamples.Samples.UpdateStatSample
Description: This sample creates and continuously update Statistic object named 'MYSTAT'. After running this sample statistics 'MYSTAT' will be available for create_delete_stat sample
--------------------------------------------------------------------------------
SampleName: whisper
Implemented in OMSamples.Samples.WhisperSample
Parameters:
	arg1 - Specifies extension which will "barge in" to the call.
	arg2 - Specifies participant who will hear the extension added to the call.

Description: Shows how to use PBXAPI.BargeIn() to listen call and whisper to specific call participant.
--------------------------------------------------------------------------------
