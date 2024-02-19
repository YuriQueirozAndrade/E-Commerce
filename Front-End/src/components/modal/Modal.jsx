import "./modal.css"
export default function Modal({children, mWidth,mHeight,mBorder})
{
  return (
  <div className="modal" style={{width: mWidth, height: mHeight, borderRadius: mBorder,}}>
    {children}
  </div>
  )
}
