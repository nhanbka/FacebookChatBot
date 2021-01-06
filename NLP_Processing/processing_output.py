
def label_to_text(label):
    switcher = {
        0: u'Khuyến mãi, phụ kiện đi kèm',
        1: u'So sánh sản phẩm',
        2: u'Mua bán phụ kiện riêng',
        3: u'Tư vấn chăm sóc khách hàng',
        4: u'Sửa chữa, bảo hành sản phầm',
        5: u'Đánh giá sản phẩm',
        6: u'Giá tiền, mua bán, trả góp, ...',
        7: u'Trạng thái mặt hàng'
    }
    return switcher.get(label, "Khác (như chê bai, khen ngợi)")
