
import Modal from "@components/modal/Modal.jsx";
import "@components/productImage/image.css";
export default function Image({iWidth,iHeigth})
{
  return (
    <Modal>
      <div className="product-image">
        <img src="#" width={iWidth} height={iHeigth} />
      </div>
    </Modal>
  )
}

