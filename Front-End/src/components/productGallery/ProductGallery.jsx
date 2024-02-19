import Image from "@components/productImage/ProductImage.jsx"
import "@components/productGallery/gallery.css";
export default function Gallery()
{
  const smallSize = '200px';
  const bigSize = "600px";
  return (
  <div className="gallery">
    <Image iWidth={bigSize} iHeigth={bigSize} />
    <ul className="bottomImages">
      <li><Image iWidth={smallSize} iHeigth={smallSize} /></li>
      <li><Image iWidth={smallSize} iHeigth={smallSize} /></li>
      <li><Image iWidth={smallSize} iHeigth={smallSize} /></li>
    </ul>
  </div>
  )
}


