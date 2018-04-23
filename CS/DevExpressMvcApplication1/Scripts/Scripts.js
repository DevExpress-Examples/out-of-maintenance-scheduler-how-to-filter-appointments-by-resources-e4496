var textSeparator = ";";
function OnListBoxSelectionChanged(listBox, args) {
    if (args.index == 0)
        args.isSelected ? listBox.SelectAll() : listBox.UnselectAll();
    UpdateSelectAllItemState();
    UpdateText();
}
function UpdateSelectAllItemState() {
    IsAllSelected() ? checkListBox.SelectIndices([0]) : checkListBox.UnselectIndices([0]);
}
function IsAllSelected() {
    for (var i = 1; i < checkListBox.GetItemCount() ; i++)
        if (!checkListBox.GetItem(i).selected)
            return false;
    return true;
}
function UpdateText() {
    var selectedItems = checkListBox.GetSelectedItems();
    checkComboBox.SetText(GetSelectedItemsText(selectedItems));
}
function SynchronizeListBoxValues(dropDown, args) {
    checkListBox.UnselectAll();
    var texts = dropDown.GetText().split(textSeparator);
    var values = GetValuesByTexts(texts);
    checkListBox.SelectValues(values);
    UpdateSelectAllItemState();
    UpdateText(); // for remove non-existing texts
}
function GetSelectedItemsText(items) {
    var texts = [];
    for (var i = 0; i < items.length; i++)
        if (items[i].index != 0)
            texts.push(items[i].text);
    return texts.join(textSeparator);
}
function GetValuesByTexts(texts) {
    var actualValues = [];
    var item;
    for (var i = 0; i < texts.length; i++) {
        item = checkListBox.FindItemByText(texts[i]);
        if (item != null)
            actualValues.push(item.value);
    }
    return actualValues;
}

function OnCloseButtonClick(s, e) {
    checkComboBox.HideDropDown();
    scheduler.PerformCallback();
}
function OnDropDownClose(s, e) {
    scheduler.PerformCallback();
}

function OnBeginSchedulerCallback(s, e) {
    e.customArgs['SelectedResources'] = checkListBox.GetSelectedValues().join(textSeparator);
}