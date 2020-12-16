function clickItemHandler(itemId, mainButtonId) {
    var newText = document.getElementById('itemNameId_' + itemId).innerHTML
    document.getElementById('mainButton_' + mainButtonId).value = newText
    document.getElementById('mainButtonLabel_' + mainButtonId).innerHTML = newText
}
