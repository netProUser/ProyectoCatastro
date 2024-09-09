CKEDITOR.editorConfig = function (config) {
    config.toolbar = [
	{ name: 'basicstyles', items: ['Bold', 'Italic', 'Underline'] },
	{ name: 'styles', items: ['Format', 'Font', 'FontSize'] },
	{ name: 'paragraph', items: ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'NumberedList', 'BulletedList', '-', 'Outdent', 'Indent'] },
	{ name: 'insert', items: ['Image', 'Table'] },
    
    ];
    //config.removePlugins = 'image';
    config.extraPlugins = ['justify', 'font'];
    config.language = 'es';
};