const WebGLRecoder = {
    $sharedInstance: {
        
    },
    WebGLScreenShot: function(fileName) {
        console.log('ScreenShot', Pointer_stringify(fileName));
		ScreenShot(Pointer_stringify(fileName));
    },
    WebGLStartRecording: function() {
		StartRecording();
    },
    WebGLStopRecording: function(obj) {
        console.log("WebGLRecoder: Stopping recording");
        StopRecording();
		Runtime.dynCall('v', obj, 0);
    },
    WebGLRecordDownload: function(fileName) {
        console.log('RecordDownload: ', Pointer_stringify(fileName));
        RecordDownload(Pointer_stringify(fileName));
    },
	WebGLGetStudentName: function(){
		var name = getStudentNameFromLocal();
		console.log('name:'+name);
		//Get size of the string
		var bufferSize = lengthBytesUTF8(name) + 1;
		//Allocate memory space
		var buffer = _malloc(bufferSize);
		//Copy old data to the new one then return it
		stringToUTF8(name, buffer, bufferSize);
		return buffer;
	},
	WebGLGetStudentNo: function(){
		var no = getStudentNoFromLocal();
		console.log('no:'+no);
		//Get size of the string
		var bufferSize = lengthBytesUTF8(no) + 1;
		//Allocate memory space
		var buffer = _malloc(bufferSize);
		//Copy old data to the new one then return it
		stringToUTF8(no, buffer, bufferSize);
		return buffer;
	},
	WebGLIsLogin: function(){
       if(hasLogin()){
			return 1;
	   }else{
			return 0;
		}
	},
	WebGLLogin: function(){
        console.log('login');
		Login();
	},
	WebGLGetServerHost: function(){
		var host =  getServerHost();
        console.log('host:'+host);
		//Get size of the string
		var bufferSize = lengthBytesUTF8(host) + 1;
		//Allocate memory space
		var buffer = _malloc(bufferSize);
		//Copy old data to the new one then return it
		stringToUTF8(host, buffer, bufferSize);
		return buffer;
	},
	WebGLGetFileServerHost: function(){
		var host = getFileServerHost();
        console.log('host:'+host);
		//Get size of the string
		var bufferSize = lengthBytesUTF8(host) + 1;
		//Allocate memory space
		var buffer = _malloc(bufferSize);
		//Copy old data to the new one then return it
		stringToUTF8(host, buffer, bufferSize);
		return buffer;
	}
};
autoAddDeps(WebGLRecoder, "$sharedInstance"),
mergeInto(LibraryManager.library, WebGLRecoder);