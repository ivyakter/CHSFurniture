/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    //config.toolbar_Basic =
    //[
    //    ['Bold', 'Italic', '-', 'NumberedList', 'BulletedList', '-', 'Link', 'Unlink', '-', 'About']
    //];

   

    config.toolbar_Full =
    [
      
        '/',
        { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
        {
            name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv',
            '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock']
        },
        { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
        { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
        '/',
        { name: 'styles', items: ['Styles', 'Format', 'FontSize'] },
        { name: 'colors', items: ['TextColor', 'BGColor'] },
        { name: 'tools', items: ['Maximize', 'ShowBlocks'] }
    ];
   
    //config.toolbarGroups = [
    //       { name: 'document', groups: ['mode', 'document', 'doctools'] },
    //       { name: 'clipboard', groups: ['clipboard', 'undo'] },
    //       { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
    //       { name: 'forms', groups: ['forms'] },
    //       '/',
    //       { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
    //       { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
    //       { name: 'links', groups: ['links'] },
    //       { name: 'insert', groups: ['insert'] },
    //       '/',
    //       { name: 'styles', groups: ['styles'] },
    //       { name: 'colors', groups: ['colors'] },
    //       { name: 'tools', groups: ['tools'] },
    //       { name: 'others', groups: ['others'] },
    //       { name: 'about', groups: ['about'] }
    //];
    


   

    
};
