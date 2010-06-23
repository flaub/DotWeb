$Class(null, 'System', 'Exception', { message: null, _InnerException_k__BackingField: null, _Source_k__BackingField: null, _StackTrace_k__BackingField: null });

System.Exception.prototype.set_Message = function(value) {
	this.message = value;
};

System.Exception.prototype.$ctor$1 = function(message) {
	this.set_Message(message);
	return this;
};
