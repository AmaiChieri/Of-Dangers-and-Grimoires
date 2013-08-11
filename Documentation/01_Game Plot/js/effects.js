 $(document).ready(function(){  
	$( ".short" ).dialog({
							autoOpen: false,
							show: {
							effect: "clip",
							duration: 300
							},
							hide: {
							effect: "clip",
							duration: 200
							}
	});

});

function AA(){
	$(" .short ").dialog("close");
	$( "#beginning-story" ).dialog( "open" );
}
function AB(){
	$(" .short ").dialog("close");
	$( "#beginning-grimoire" ).dialog( "open" );
}
function AC(){
	$(" .short ").dialog("close");
	$( "#beginning-search" ).dialog( "open" );
}
function AD(){
	$(" .short ").dialog("close");
	$( "#beginning-attacked" ).dialog( "open" );
}
function AE(){
	$(" .short ").dialog("close");
	$( "#beginning-start" ).dialog( "open" );
}
function BA(){
	$(" .short ").dialog("close");
	$( "#genius-meeting" ).dialog( "open" );
}
function CA(){
	$(" .short ").dialog("close");
	$( "#hag-meeting" ).dialog( "open" );
}

function CB(){
	$(" .short ").dialog("close");
	$( "#hag-payment" ).dialog( "open" );
}

function BB(){
	$(" .short ").dialog("close");
	$( "#genius-monica" ).dialog( "open" );
}

function BC(){
	$(" .short ").dialog("close");
	$( "#genius-rumors" ).dialog( "open" );
}

function BD(){
	$(" .short ").dialog("close");
	$( "#genius-directions" ).dialog( "open" );
}

function DA(){
	$(" .short ").dialog("close");
	$( "#lighthouse-reach" ).dialog( "open" );
}

function EA(){
	$(" .short ").dialog("close");
	$( "#Dragon-reach" ).dialog( "open" );
}

function FA(){
	$(" .short ").dialog("close");
	$( "#Grimoire-obtain" ).dialog( "open" );
}

function GA(){
$(" .short ").dialog("close");
	$( "#Ending-Bring" ).dialog( "open" );
}

function GB(){
$(" .short ").dialog("close");
	$( "#Ending-NotBring" ).dialog( "open" );
}