// Script to 'reset' current webpartmanager
// Note: only used for ASP.NET 2.0 WebPart framework
function WebPartManager_Cleanup() {
	if (__wpm != null && __wpm.zones != null)
	{
		//loop zones
		for (var i = 0; i < __wpm.zones.length; i++)
		{
			var zone = __wpm.zones[i];
			//detach current zone events
			if (zone.webPartTable != null)
			{
				zone.webPartTable.detachEvent('ondragenter', Zone_OnDragEnter);
				zone.webPartTable.detachEvent('ondrop', Zone_OnDrop);
				zone.webPartTable.detachEvent('ondrop', Zone_OnDrop);
			}
			//loop webparts of current zone
			if (zone.webParts != null)
			{
				for (var j = 0; j < zone.webParts.length; j++)
				{
					var webpart = zone.webParts[j];
					//detach current webpart events
					webpart.webPartElement.detachEvent('ondragstart', WebPart_OnDragStart);
					webpart.webPartElement.detachEvent('ondrag', WebPart_OnDrag);
					webpart.webPartElement.detachEvent('ondragend', WebPart_OnDragEnd);
				}
			}
			//dispose zone
			__wpm.zones[i].Dispose();
		}
		//reset zone array in webpartmanager
		__wpm.zones = new Array();
	}
}
