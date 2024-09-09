CKEDITOR.editorConfig = function (config) {
    config.toolbar = [
	{ name: 'basicstyles', items: ['Bold', 'Italic', 'Underline'] },
	{ name: 'styles', items: ['Format', 'Font', 'FontSize'] },
	{ name: 'paragraph', items: ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'NumberedList', 'BulletedList', '-', 'Outdent', 'Indent'] },
	{ name: 'insert', items: ['Image', 'Table'] },
    
    ];
    config.extraPlugins = ['justify', 'font'];
    //config.extraPlugins = 'font';
    //config.extraPlugins = 'filebrowser';
    //config.removePlugins = 'image';
    //config.extraPlugins = 'easyimage';
    config.language = 'es';
};