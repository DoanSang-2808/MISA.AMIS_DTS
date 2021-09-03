function formatGender(gender) {
    let result = '';
    switch (gender) {
        case 0:
            result = "Nữ";
            break;
        case 1:
            result = "Nam";
            break;
        case 2:
            result = "Khác";
            break;
        default:
            result = '';
            break;
    }
    return result;
}
export {formatGender}